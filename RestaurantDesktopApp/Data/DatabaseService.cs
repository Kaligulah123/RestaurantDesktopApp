using Microsoft.Maui.Controls;
using RestaurantDesktopApp.MVVM.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDesktopApp.Data
{
    public class DatabaseService : IAsyncDisposable
    {
        //Campos
        #region Campos

        private readonly SQLiteAsyncConnection _connection;

        #endregion


        //Constructor
        #region Constructor

        public DatabaseService()
        {
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "restdesktop.db3");

            _connection = new SQLiteAsyncConnection(dbPath, SQLiteOpenFlags.Create | SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.SharedCache);
        }

        #endregion


        //Inicializar base de datos
        #region Initialize
        public async Task InitializeDatabaseAsync()
        {
            await _connection.CreateTableAsync<MenuCategory>();
            await _connection.CreateTableAsync<MenuItem>();
            await _connection.CreateTableAsync<MenuItemCategoryMapping>();
            await _connection.CreateTableAsync<Order>();
            await _connection.CreateTableAsync<OrderItem>();

            await SeedDataAsync();
          
        }

        private async Task SeedDataAsync()
        {
            var firstCategory = await _connection.Table<MenuCategory>().FirstOrDefaultAsync();

            if (firstCategory != null) return; //Si tenemos ya una categoria en la tabla, no debemos recargar los datos        

            var categories = SeedData.GetMenuCategories();
            var menuItems = SeedData.GetMenuItems();
            var mappings = SeedData.GetMenuItemCategoryMappings();

            await _connection.InsertAllAsync(categories);
            await _connection.InsertAllAsync(menuItems);
            await _connection.InsertAllAsync(mappings);
        }
        #endregion


        //Metodos
        #region Metodos

        public async Task<MenuCategory[]> GetMenuCategoriesAsync() => await _connection.Table<MenuCategory>().ToArrayAsync();     

        public async Task<MenuItem[]> GetMenuItemsByCategoryAsync(int categoryId)
        {
            var query = @"
                        SELECT menu.*
                        FROM MenuItem AS menu
                        INNER JOIN MenuItemCategoryMapping AS mapping
                        ON menu.Id = mapping.MenuItemId
                        WHERE mapping.MenuCategoryId = ?
                        ";

            var menuItems = await _connection.QueryAsync<MenuItem>(query, categoryId);

            return [..menuItems];
        }

        public async Task<string?> PlaceOrderAsync(OrderModel model)
        {
            var order = new Order
            {               
                OrderDate = model.OrderDate,
                PaymentMode = model.PaymentMode,
                TotalAmountPaid = model.TotalAmountPaid,
                TotalItemsCount = model.TotalItemsCount,
            };

            if(await _connection.InsertAsync(order) > 0)
            {
                //Order Inserted succesfully
                //Now we have newly inserted order Id in (order.Id)
                //Now we can add the orderId to the OrderItems and Insert OrderItems in the database
                foreach (var item in model.Items)
                {
                    item.OrderId = order.Id;
                }

                if(await _connection.InsertAllAsync(model.Items) == 0)
                {
                    //OrderItems Insert operation failed
                    //Remove the Newly Inserted Order
                    await _connection.DeleteAsync(order);
                    return "Error al insertar OrderItems";
                }               
            }
            else
            {
                return "Error al insertar la Orden";
            }

            model.Id = order.Id;

            return null;
        }

        public async Task<Order[]> GetOrdersAsync() => await _connection.Table<Order>().ToArrayAsync();

        public async Task<OrderItem[]> GetOrderItemsAsync(long orderId) => await _connection.Table<OrderItem>().Where(x => x.OrderId == orderId).ToArrayAsync();

        public async Task<MenuCategory[]> GetCategoriesOfMenuItemAsync(int menuItemId)
        {
            var query = @"
                        SELECT cat.*
                        FROM MenuCategory cat
                        INNER JOIN MenuItemCategoryMapping map
                        ON cat.Id = map.MenuCategoryId
                        WHERE map.menuItemId = ?
                        ";

            var categories = await _connection.QueryAsync<MenuCategory>(query, menuItemId);

            return [.. categories];
        }

        public async Task<string?> SaveMenuItemAsync(MenuItemModel model)
        {
            if(model.Id == 0)
            {
                //Creating a new menu item
                MenuItem menuItem = new()
                {
                    Id = model.Id,
                    Name = model.Name,
                    Description = model.Description,
                    Icon = model.Icon,
                    Price = model.Price
                };

                if(await _connection.InsertAsync(menuItem) > 0)
                {
                    var categoryMapping = model.SelectedCategories                                                        
                                                        .Select(x => new MenuItemCategoryMapping
                                                        {
                                                            Id = x.Id,
                                                            MenuCategoryId = x.Id,
                                                            MenuItemId = menuItem.Id
                                                        });

                    if(await _connection.InsertAllAsync(categoryMapping) > 0)
                    {
                        model.Id = menuItem.Id;

                        return null;
                    }
                    else
                    {
                        await _connection.DeleteAsync(menuItem);                        
                    }
                }

                return "Error in saving menu item";
            }
            else
            {
                //Updating an existing menu item

                string? errorMessage = null;

                await _connection.RunInTransactionAsync(db =>
                {
                    var menuItem = db.Find<MenuItem>(model.Id);

                    menuItem.Name = model.Name;
                    menuItem.Description = model.Description;
                    menuItem.Icon = model.Icon;
                    menuItem.Price = model.Price;

                    if(db.Update(menuItem) == 0)
                    {
                        //Operation failed

                        errorMessage = "Error al actualizar el producto";

                        throw new Exception(); //To trigger rollback
                    }

                    var deleteQuery = @"
                                        DELETE FROM MenuItemCategoryMapping
                                        WHERE MenuItemId =?
                                      ";

                    db.Execute(deleteQuery, menuItem.Id);

                    var categoryMapping = model.SelectedCategories
                                                       .Select(x => new MenuItemCategoryMapping
                                                       {
                                                           Id = x.Id,
                                                           MenuCategoryId = x.Id,
                                                           MenuItemId = menuItem.Id
                                                       });

                    if(db.InsertAll(categoryMapping) == 0)
                    {
                        //Operation failed

                        errorMessage = "Error al actualizar el producto";

                        throw new Exception(); //To trigger rollback
                    }
                });

                return errorMessage;
            }
        }

        public async Task<string?> DeleteMenuItemAsync(MenuItemModel model)
        {
            string? errorMessage = null;

            // Verificar que el MenuItem tiene un Id válido antes de intentar eliminarlo
            if (model.Id > 0)
            {
                // Crear el objeto para eliminar el MenuItem
                MenuItem menuItem = new()
                {
                    Id = model.Id,
                    Name = model.Name,
                    Description = model.Description,
                    Icon = model.Icon,
                    Price = model.Price
                };

                // Eliminar el MenuItem de la base de datos
                if (await _connection.DeleteAsync(menuItem) > 0)
                {
                    // Obtener todos los mapeos de categorías asociados al MenuItem que estamos eliminando
                    var categoryMappings = await _connection.Table<MenuItemCategoryMapping>()
                                                   .Where(x => x.MenuItemId == menuItem.Id)
                                                   .ToListAsync();

                    // Eliminar los mapeos de la base de datos
                    foreach (var mapping in categoryMappings)
                    {
                        await _connection.DeleteAsync(mapping);
                    }

                    return null; // Éxito, no hay error
                }

                return "Error al borrar el menu item";
            }           
            else
            {
                errorMessage = "El producto no tiene un Id válido para eliminar.";
            }

            return errorMessage;
        }
        

        public async ValueTask DisposeAsync()
        {
            if (_connection != null)
            {
                await _connection.CloseAsync();
            }
        }

        #endregion




    }
}

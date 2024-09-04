﻿using SQLite;
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

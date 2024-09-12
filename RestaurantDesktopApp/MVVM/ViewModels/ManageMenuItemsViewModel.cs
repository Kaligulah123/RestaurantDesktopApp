using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using RestaurantDesktopApp.Data;
using RestaurantDesktopApp.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MenuItem = RestaurantDesktopApp.Data.MenuItem;
//using MenuItemModel = RestaurantDesktopApp.MVVM.Models;

namespace RestaurantDesktopApp.MVVM.ViewModels
{
    public partial class ManageMenuItemsViewModel : ObservableObject
    {
        //Campos
        #region Campos

        private readonly DatabaseService _databaseService;

        private bool _isInitialized;

        [ObservableProperty]
        private MenuCategoryModel[] _categories = [];

        [ObservableProperty]
        private MenuCategoryModel? _selectedCategory = null;

        [ObservableProperty]
        private MenuItem[] _menuItems = [];

        [ObservableProperty]
        private bool _isBusy;

        [ObservableProperty]
        private MenuItemModel _menuItem = new();

        #endregion


        //Constructor
        #region Constructor

        public ManageMenuItemsViewModel(DatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        #endregion


        //Metodos
        #region Metodos

        public async ValueTask InitializeAsync()
        {
            if (_isInitialized) return;

            _isInitialized = true;

            IsBusy = true;

            Categories = (await _databaseService.GetMenuCategoriesAsync())
                            .Select(MenuCategoryModel.FromEntity)
                            .ToArray();

            // Preseleccionar la primera categoria

            Categories[0].IsSelected = true;

            SelectedCategory = Categories[0];

            MenuItems = await _databaseService.GetMenuItemsByCategoryAsync(SelectedCategory.Id);

            SetEmptyCategoriesToItem();

            IsBusy = false;
        }


        private void SetEmptyCategoriesToItem()
        {
            MenuItem.Categories.Clear();

            foreach (var category in Categories)
            {
                var categoryOfItem = new MenuCategoryModel
                {
                    Id = category.Id,
                    Icon = category.Icon,
                    Name = category.Name,
                    IsSelected = false
                };

                MenuItem.Categories.Add(categoryOfItem);
            }
        }

        #endregion


        //Comandos
        #region Comandos

        [RelayCommand]
        private async Task SelectCategoryAsync(int categoryId)
        {
            if (SelectedCategory?.Id == categoryId) return;

            IsBusy = true;

            var existingSelectedCategory = Categories.First(x => x.IsSelected);

            existingSelectedCategory.IsSelected = false;

            var newlySelectedCategory = Categories.First(x => x.Id == categoryId);

            newlySelectedCategory.IsSelected = true;

            SelectedCategory = newlySelectedCategory;

            MenuItems = await _databaseService.GetMenuItemsByCategoryAsync(SelectedCategory.Id);

            IsBusy = false;
        }


        [RelayCommand]
        private async Task EditMenuItemAsync(MenuItem menuItem)
        {
            //await Shell.Current.DisplayAlert("Editar", "Editar Producto", "Ok");
            var menuItemModel = new MenuItemModel
            {                          
                Id = menuItem.Id,
                Name = menuItem.Name,
                Price = menuItem.Price,
                Icon = menuItem.Icon,
                Description = menuItem.Description
            };

            var itemCategories = await _databaseService.GetCategoriesOfMenuItemAsync(menuItem.Id);

            foreach ( var category in Categories)
            {
                var categoryOfItem = new MenuCategoryModel
                {
                    Id = category.Id,
                    Name = category.Name,
                    Icon = category.Icon,
                };

                if(itemCategories.Any(x => x.Id == category.Id))
                {
                    categoryOfItem.IsSelected = true;
                }
                else
                {
                    categoryOfItem.IsSelected = false;
                }

                menuItemModel.Categories.Add(categoryOfItem);
            }

            MenuItem = menuItemModel;
        }


        [RelayCommand]      
        private void Cancel()
        {
            MenuItem = new();

            SetEmptyCategoriesToItem();
        }


        [RelayCommand]
        private async Task SaveMenuItemAsync(MenuItemModel model)
        {
            IsBusy = true;

            var errorMessage = await _databaseService.SaveMenuItemAsync(model);

            if (errorMessage != null)
            {
                await Shell.Current.DisplayAlert("Error", errorMessage, "Ok");
            }
            else
            {             
                await Toast.Make("Producto guardado exitosamente").Show();

                HandleMenuItemChanged(model);

                //Send the updated menu item details to the other parts of the App

                //WeakReferenceMessenger.Default.Send(new MenuItemChangedMessage(model));
                WeakReferenceMessenger.Default.Send(MenuItemChangedMessage.From(model));

                Cancel();
            }

            IsBusy = false;
        }


        [RelayCommand]
        private async Task DeleteMenuItemAsync(MenuItemModel model)
        {
            IsBusy = true;

            var errorMessage = await _databaseService.DeleteMenuItemAsync(model);

            if (errorMessage != null)
            {
                await Shell.Current.DisplayAlert("Error", errorMessage, "Ok");
            }
            else
            {
                await Toast.Make("Producto eliminado exitosamente").Show();
               
                MenuItems = [.. MenuItems.Where(x => x.Id != model.Id)];
                
                //Send the deleted menu item to the other parts of the App
                WeakReferenceMessenger.Default.Send(MenuItemDeletedMessage.From(model));

                Cancel();
            }

            IsBusy = false;
        }

        private void HandleMenuItemChanged(MenuItemModel model)
        {
            var menuItem = MenuItems.FirstOrDefault(x => x.Id == model.Id);

            if (menuItem != null)
            {
                //This menu item is on the screen right now

                //Check if the item is on selected category
                if(!model.SelectedCategories.Any(x => x.Id == SelectedCategory.Id))
                {
                    // No longer belongs to the selected category
                    //Remove the item from the current UI Menu Items List
                    MenuItems = [.. MenuItems.Where(x => x.Id != model.Id)];

                    return;
                }

                //Update the dtails
                menuItem.Name = model.Name;
                menuItem.Description = model.Description;
                menuItem.Icon = model.Icon;
                menuItem.Price = model.Price;

                MenuItems = [.. MenuItems];
            }
            else if (model.SelectedCategories.Any(x => x.Id == SelectedCategory.Id))
            {
                //Item was not on the UI
                //We updated the item adding this currently selected category

                var newMenuItem = new MenuItem
                {
                    Id = model.Id,
                    Name = model.Name,
                    Description = model.Description,
                    Icon = model.Icon,
                    Price = model.Price,
                };

                MenuItems = [.. MenuItems, newMenuItem];
            }
        }
     

        #endregion

    }
}

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RestaurantDesktopApp.Data;
using RestaurantDesktopApp.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDesktopApp.MVVM.ViewModels
{
    public partial class MainPageViewModel : ObservableObject
    {
        //Campos
        #region Campos

        private readonly DatabaseService _databaseService;

        private bool _isInitialized;        

        [ObservableProperty]
        public MenuCategoryModel[] _categories = [];

        [ObservableProperty]
        public MenuCategoryModel? __selectedCategory = null;

        [ObservableProperty]
        private bool _isBusy;

        #endregion


        //Constructor
        #region Constructor

        public MainPageViewModel(DatabaseService databaseService)
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

            IsBusy = false;
        }

        #endregion


        //Comandos
        #region Comandos

        [RelayCommand]
        private void SelectCategory(int categoryId)
        {
            if (SelectedCategory.Id == categoryId) return;

            var existingSelectedCategory = Categories.First(x => x.IsSelected);

            existingSelectedCategory.IsSelected = false;

            var newlySelectedCategory = Categories.First(x => x.Id == categoryId);

            newlySelectedCategory.IsSelected = true;

            SelectedCategory = newlySelectedCategory;
        }

        #endregion

    }
}

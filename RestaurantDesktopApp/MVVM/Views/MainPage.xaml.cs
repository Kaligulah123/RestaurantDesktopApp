using CommunityToolkit.Mvvm.Messaging;
using RestaurantDesktopApp.MVVM.Models;
using RestaurantDesktopApp.MVVM.ViewModels;
using MenuItem = RestaurantDesktopApp.Data.MenuItem;

namespace RestaurantDesktopApp.MVVM.Views
{
    public partial class MainPage : ContentPage
    {
        private readonly MainPageViewModel _mainPageViewModel;

        public SettingsViewModel _settingsViewModel;

        public MainPage(MainPageViewModel mainPageViewModel, SettingsViewModel settingsViewModel)
        {
            InitializeComponent();

            _mainPageViewModel = mainPageViewModel;

            _settingsViewModel = settingsViewModel;

            BindingContext = _mainPageViewModel;

            Initialize();

            WeakReferenceMessenger.Default.Register<ShowOrderMessage>(this, async (recipient, message) =>
            {
                await ShowTemporaryMessage();
            });
        }

        protected override async void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            await _settingsViewModel.InitializeAsync();
        }

        private async void Initialize()
        {
            await _mainPageViewModel.InitializeAsync();
        }

        private async void CategoriesListControl_OnCategorySelected(Models.MenuCategoryModel category)
        {
            await _mainPageViewModel.SelectCategoryCommand.ExecuteAsync(category.Id);
        }

        private void MenuItemsListControl_OnSelectItem(MenuItem menuItem)
        {
            _mainPageViewModel.AddToCartCommand.Execute(menuItem);
        }

        public async Task ShowTemporaryMessage()
        {
            // Aparecer el texto (opacidad de 0 a 1)
            await MessageLabel.FadeTo(1, 300);
          
            await Task.Delay(1000);

            // Desaparecer el texto progresivamente (opacidad de 1 a 0)
            await MessageLabel.FadeTo(0, 300);
        }
               
    }

}

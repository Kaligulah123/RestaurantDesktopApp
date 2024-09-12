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
    }

}

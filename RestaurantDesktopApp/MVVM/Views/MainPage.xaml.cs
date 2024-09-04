using RestaurantDesktopApp.MVVM.ViewModels;

namespace RestaurantDesktopApp.MVVM.Views
{
    public partial class MainPage : ContentPage
    {
        private readonly MainPageViewModel _mainPageViewModel;

        public MainPage(MainPageViewModel mainPageViewModel)
        {
            InitializeComponent();

            _mainPageViewModel = mainPageViewModel;

            BindingContext = _mainPageViewModel;

            Initialize();
        }

        private async void Initialize()
        {
            await _mainPageViewModel.InitializeAsync();
        }      

    }

}

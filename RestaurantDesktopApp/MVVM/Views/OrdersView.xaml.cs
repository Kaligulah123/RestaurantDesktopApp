using RestaurantDesktopApp.MVVM.ViewModels;

namespace RestaurantDesktopApp.MVVM.Views;

public partial class OrdersView : ContentPage
{
    private readonly OrdersViewModel _ordersViewModel;

    public OrdersView(OrdersViewModel ordersViewModel)
	{
		InitializeComponent();

        _ordersViewModel = ordersViewModel;

        BindingContext = _ordersViewModel;

        InitializeViewModelAsync();
    }

    private async void InitializeViewModelAsync() => await _ordersViewModel.InitializeAsync();
}
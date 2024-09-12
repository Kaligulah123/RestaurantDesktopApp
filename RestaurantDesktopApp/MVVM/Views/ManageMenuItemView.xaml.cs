using RestaurantDesktopApp.MVVM.ViewModels;

namespace RestaurantDesktopApp.MVVM.Views;

public partial class ManageMenuItemView : ContentPage
{
    private readonly ManageMenuItemsViewModel _manageMenuItemsViewModel;

    public ManageMenuItemView(ManageMenuItemsViewModel manageMenuItemsViewModel)
	{
		InitializeComponent();

        _manageMenuItemsViewModel = manageMenuItemsViewModel;

        BindingContext = _manageMenuItemsViewModel;

        InitializeAsync();
    }

    private async void InitializeAsync() => await _manageMenuItemsViewModel.InitializeAsync();

    private async void CategoriesListControl_OnCategorySelected(Models.MenuCategoryModel category) => await _manageMenuItemsViewModel.SelectCategoryCommand.ExecuteAsync(category.Id);    

    private async void MenuItemsListControl_OnSelectItem(Data.MenuItem menuItem) => await _manageMenuItemsViewModel.EditMenuItemCommand.ExecuteAsync(menuItem);

    private void SaveMenuItemControl_OnCancel()
    {
        _manageMenuItemsViewModel.CancelCommand.Execute(null);
    }

    private async void SaveMenuItemControl_OnSaveItem(Models.MenuItemModel menuItemModel)
    {
        await _manageMenuItemsViewModel.SaveMenuItemCommand.ExecuteAsync(menuItemModel);
    }
}
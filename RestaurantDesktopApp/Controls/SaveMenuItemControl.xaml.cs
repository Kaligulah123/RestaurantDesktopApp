using CommunityToolkit.Mvvm.Input;
using RestaurantDesktopApp.MVVM.Models;

namespace RestaurantDesktopApp.Controls;

public partial class SaveMenuItemControl : ContentView
{
    private const string DefaultIcon = "image_add_regular_36.png";
    public string? ExistingIcon { get; set; }

    public SaveMenuItemControl()
	{
		InitializeComponent();
	} 

    public static readonly BindableProperty ItemProperty = BindableProperty.Create(nameof(Item), typeof(MenuItemModel), typeof(SaveMenuItemControl), new MenuItemModel(), propertyChanged: OnItemChanged);   

    public MenuItemModel Item
    {
        get => (MenuItemModel)GetValue(ItemProperty);

        set => SetValue(ItemProperty, value);
    }

    private static void OnItemChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (newValue is MenuItemModel menuItemModel)
        {
            if(bindable is SaveMenuItemControl thisControl)
            {
                if (menuItemModel.Id > 0)
                {                   
                    thisControl.SetIconImage(false, menuItemModel.Icon, thisControl);

                    thisControl.ExistingIcon = menuItemModel.Icon;
                }
                else
                {                  
                    thisControl.SetIconImage(true, null, thisControl);
                }               
            }
        }
    }


    [RelayCommand]
    private void ToggleCategorySelection(MenuCategoryModel category) => category.IsSelected = !category.IsSelected;


    public event Action? OnCancel;


    [RelayCommand]
    private void Cancel() => OnCancel?.Invoke();

    private async void PickImageButton_Clicked(object sender, EventArgs e)
    {
        var fileResult = await MediaPicker.PickPhotoAsync();

        if (fileResult != null)
        {
            //Upload/Save image
            var imageStream = await fileResult.OpenReadAsync();

            var localPath = Path.Combine(FileSystem.AppDataDirectory, fileResult.FileName);

            using var fs = new FileStream(localPath, FileMode.Create, FileAccess.Write);

            await imageStream.CopyToAsync(fs);

            //Update imageIcon on the UI           

            SetIconImage(isDefault: false, localPath);

            Item.Icon = localPath;
        }
        else
        {
            //User canceled from Image Picker Dialog          

           

            if(ExistingIcon != null)
            {
                SetIconImage(isDefault: false, ExistingIcon);
            }
            else
            {
                SetIconImage(isDefault: true);
            }
        }        
    }

    public void SetIconImage(bool isDefault, string? iconSource = null, SaveMenuItemControl? control = null)
    {
        int size = 100;

        if (isDefault)
        {
            iconSource = DefaultIcon;

            size = 36;
        }

        control = control ?? this;

        control.itemIcon.Source = iconSource;

        control.itemIcon.HeightRequest = control.itemIcon.WidthRequest = size;
    }

    public event Action<MenuItemModel> OnSaveItem;

    [RelayCommand]
    private async Task SaveMenuItemAsync()
    {
        if(string.IsNullOrWhiteSpace(Item.Name) || string.IsNullOrWhiteSpace(Item.Description))
        {
            await ErrorAlertAsync("Se requiere nombre y descripción");

            return;
        }

        if(Item.SelectedCategories.Length == 0)
        {
            await ErrorAlertAsync("Por favor seleccione al menos una categoría");

            return;
        }

        if(Item.Icon == DefaultIcon)
        {
            await ErrorAlertAsync("Se requiere una imagen");

            return;
        }

        OnSaveItem?.Invoke(Item);

        static async Task ErrorAlertAsync(string message) => await Shell.Current.DisplayAlert("Error de validación", message, "Ok");


    }
}
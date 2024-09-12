using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RestaurantDesktopApp.Data;
using RestaurantDesktopApp.MVVM.Models;
using MenuItem = RestaurantDesktopApp.Data.MenuItem;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Messaging;
using System.Reflection;
namespace RestaurantDesktopApp.MVVM.ViewModels
{
    public partial class MainPageViewModel : ObservableObject, IRecipient<MenuItemChangedMessage>, IRecipient<MenuItemDeletedMessage>
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
        public ObservableCollection<CartModel> CartItems { get; set; } = new();

        [ObservableProperty, NotifyPropertyChangedFor(nameof(TaxAmount)), NotifyPropertyChangedFor(nameof(Total))]
        private decimal _subtotal;

        [ObservableProperty, NotifyPropertyChangedFor(nameof(TaxAmount)), NotifyPropertyChangedFor(nameof(Total))]
        private int _taxPercentage;

        public decimal TaxAmount => (Subtotal * TaxPercentage) / 100;

        public decimal Total => Subtotal + TaxAmount;

        private readonly OrdersViewModel _ordersViewModel;

        private readonly SettingsViewModel _settingsViewModel;

        [ObservableProperty]
        private string _name = "Invitado";

        #endregion


        //Constructor
        #region Constructor

        public MainPageViewModel(DatabaseService databaseService, OrdersViewModel ordersViewModel, SettingsViewModel settingsViewModel)
        {
            _databaseService = databaseService;

            _ordersViewModel = ordersViewModel;

            _settingsViewModel = settingsViewModel;

            CartItems.CollectionChanged += CartItems_CollectionChanged;

            WeakReferenceMessenger.Default.Register<MenuItemChangedMessage>(this);

            // Registro para recibir mensajes de eliminación de MenuItem
            WeakReferenceMessenger.Default.Register<MenuItemDeletedMessage>(this);

            WeakReferenceMessenger.Default.Register<NameChangedMessage>(this, (recipient, message) => Name = message.Value);

            //Get TaxPercentage from Preferences
            TaxPercentage = _settingsViewModel.GetTaxPercentage();
        }

        private void CartItems_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            // Se ejecuta cuando se añade o elimina algun elemento a la coleccion
            // y también cuando se borra toda la colección
            RecalculateAmount();
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

            IsBusy = false;          
        }

        private void RecalculateAmount()
        {
            Subtotal = CartItems.Sum(x => x.Amount);
        }

        public void Receive(MenuItemChangedMessage message)
        {
            var model = message.Value;

            var menuItem = MenuItems.FirstOrDefault(x => x.Id == model.Id);

            if (menuItem != null)
            {
                //This menu item is on the screen right now

                //Check if the item is on selected category
                if (!model.SelectedCategories.Any(x => x.Id == SelectedCategory.Id))
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

            //Check if the updated menu item is added in the cart
            var cartItem = CartItems.FirstOrDefault(x => x.ItemId == model.Id);

            if (cartItem != null)
            {
                cartItem.Name = model.Name;
                cartItem.Price = model.Price;
                cartItem.Icon = model.Icon;

                var itemIndex = CartItems.IndexOf(cartItem);

                //It will trigger CollectionChanged event and now can recalculate amount
                CartItems[itemIndex] = cartItem;
            }
        }

        public void Receive(MenuItemDeletedMessage message)
        {
            var model = message.Value;

            MenuItems = [.. MenuItems.Where(x => x.Id != model.Id)];

            var itemToRemove = CartItems.FirstOrDefault(x => x.ItemId == model.Id);

            if (itemToRemove != null)
            {
                CartItems.Remove(itemToRemove);
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

        private void AddToCart(MenuItem menuItem)
        {
            var cartItem = CartItems.FirstOrDefault( x => x.ItemId == menuItem.Id);

            if (cartItem == null)
            {
                cartItem = new CartModel
                {
                    ItemId = menuItem.Id,
                    Icon = menuItem.Icon,
                    Name = menuItem.Name,
                    Price = menuItem.Price,
                    Quantity = 1
                };

                CartItems.Add(cartItem);
            }
            else
            {
                cartItem.Quantity++;
                RecalculateAmount();
            }
        }


        [RelayCommand]
        private void IncreaseQuantity(CartModel cartItem)
        {
            cartItem.Quantity++;

            RecalculateAmount();
        }
    

        [RelayCommand]
        private void DecreaseQuantity(CartModel cartItem)
        {
            cartItem.Quantity--;

            if (cartItem.Quantity == 0)
            {
                CartItems.Remove(cartItem);
            }
            else
            {
                RecalculateAmount();
            }
        }


        [RelayCommand]
        private void RemoveItemFromCart(CartModel cartItem) => CartItems.Remove(cartItem);


        [RelayCommand]
        private async void ClearCartAsync()
        {
            if(await Shell.Current.DisplayAlert("Eliminar Pedido?", "¿Está seguro de que quiere eliminar el pedido?", "SI", "NO"))
            {
                CartItems.Clear();
            }                   
        }


        [RelayCommand]
        private async Task TaxPercentageChange()
        {
            var result = await Shell.Current.DisplayPromptAsync("Importe IVA", "Añada el IVA correspondiente", placeholder: "10", initialValue: TaxPercentage.ToString());

            if (!string.IsNullOrEmpty(result))
            {
                if(!int.TryParse(result, out var enteredTaxPercentage))
                {
                    await Shell.Current.DisplayAlert("Error!", "Introduzca en valor numérico válido", "Ok");

                    return;
                }

                if (enteredTaxPercentage > 100)
                {
                    await Shell.Current.DisplayAlert("Error!", "Introduzca un valor menor a 100", "Ok");

                    return;
                }

                TaxPercentage = enteredTaxPercentage;

                //Save it in Preferences
                _settingsViewModel.SetTaxPercentage(enteredTaxPercentage);
            }
        }


        [RelayCommand]
        private async Task PlaceOrderAsync(bool isPaid)
        {
            IsBusy = true;

            //Estas dos lineas son lo mismo
            //await _ordersViewModel.PlaceOrderAsync(CartItems.ToArray(), isPaid);
            if (await _ordersViewModel.PlaceOrderAsync([.. CartItems], isPaid))
            {
                //Order creation succesfull
                CartItems.Clear();

                IsBusy = false;

                WeakReferenceMessenger.Default.Send(new ShowOrderMessage(true));
            }

            IsBusy = false;

           
        }






        #endregion

    }
}

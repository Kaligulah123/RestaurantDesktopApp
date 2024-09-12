using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
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
    public partial class OrdersViewModel : ObservableObject
    {
        //Campos
        #region Campos

        private readonly DatabaseService _databaseService;
        public ObservableCollection<OrderModel> Orders { get; set; } = [];

        private bool _isInitialized;

        [ObservableProperty]
        private bool _isBusy;

        [ObservableProperty]
        private OrderItem[] _orderItems = [];

        #endregion


        //Constructor
        #region Constructor

        public OrdersViewModel(DatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        #endregion


        //Metodos
        #region Metodos

        public async Task<bool> PlaceOrderAsync(CartModel[] cartItems, bool isPaidOnline)
        {
            var orderItems = cartItems.Select(x => new OrderItem
            {
                Icon = x.Icon,
                ItemId = x.ItemId,
                Name = x.Name,
                Price = x.Price,
                Quantity = x.Quantity,
            }).ToArray();

            var orderModel = new OrderModel
            {
                OrderDate = DateTime.Now,
                PaymentMode = isPaidOnline ? "Online" : "Cash",
                TotalAmountPaid = cartItems.Sum(x => x.Amount),
                TotalItemsCount = cartItems.Length,
                Items = orderItems
            };

            var errorMessage = await _databaseService.PlaceOrderAsync(orderModel);

            if (!string.IsNullOrEmpty(errorMessage))
            {
                await Shell.Current.DisplayAlert("Error", errorMessage, "Ok");

                return false;
            }

            //Order creation succesfully

            Orders.Add(orderModel);

            await Toast.Make("Pedido enviado correctamente").Show();

            return true;
        }

        public async ValueTask InitializeAsync()
        {
            if (_isInitialized) return;

            _isInitialized = true;

            _isBusy = true;

            Orders.Clear();

            var dbOrders = await _databaseService.GetOrdersAsync();

            var orders = dbOrders.Select(x => new OrderModel
            {
                Id = x.Id,
                OrderDate = DateTime.Now,
                PaymentMode = x.PaymentMode,
                TotalAmountPaid = x.TotalAmountPaid,
                TotalItemsCount = x.TotalItemsCount,
            });

            foreach (var order in orders)
            {
                Orders.Add(order);
            }

            _isBusy = false;
        }

        #endregion


        //Comandos
        #region Comandos

        [RelayCommand]
        private async Task SelectOrderAsync(OrderModel? order)
        {
            var preSelectedOrder = Orders.FirstOrDefault(x => x.IsSelected);

            if (preSelectedOrder != null)
            {
                preSelectedOrder.IsSelected = false;

                if(preSelectedOrder.Id == order?.Id)
                {
                    OrderItems = [];
                    return;
                }
            }

            if (order == null || order.Id == 0)
            {
                OrderItems = [];
                return;
            }

            IsBusy = true;

            order.IsSelected = true;

            OrderItems = await _databaseService.GetOrderItemsAsync(order.Id);

            IsBusy = false;
        }


        #endregion




    }
}

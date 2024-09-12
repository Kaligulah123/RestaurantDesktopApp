using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using RestaurantDesktopApp.Data;
using RestaurantDesktopApp.MVVM.ViewModels;
using RestaurantDesktopApp.MVVM.Views;

namespace RestaurantDesktopApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {                                      
                    fonts.AddFont("Poppins-Regular.ttf", "PoppinsRegular");
                    fonts.AddFont("Poppins-Bold.ttf", "PoppinsBold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<DatabaseService>();
            builder.Services.AddSingleton<MainPageViewModel>();
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<OrdersViewModel>();
            builder.Services.AddSingleton<OrdersView>();
            builder.Services.AddTransient<ManageMenuItemView>();
            builder.Services.AddTransient<ManageMenuItemsViewModel>();
            builder.Services.AddSingleton<SettingsViewModel>();

            return builder.Build();
        }
    }
}

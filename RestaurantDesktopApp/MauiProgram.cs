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
                    fonts.AddFont("Roboto-Regular.ttf", "Roboto");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<DatabaseService>();
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<MainPageViewModel>();


            return builder.Build();
        }
    }
}

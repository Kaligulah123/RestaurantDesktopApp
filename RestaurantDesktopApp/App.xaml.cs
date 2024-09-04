﻿using RestaurantDesktopApp.Data;

namespace RestaurantDesktopApp
{
    public partial class App : Application
    {
        public App(DatabaseService databaseService)
        {
            InitializeComponent();

            MainPage = new AppShell();           

            Task.Run(async() => await databaseService.InitializeDatabaseAsync())
                                                      .GetAwaiter()
                                                      .GetResult();
        } 
    }
}

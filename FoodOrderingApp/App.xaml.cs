﻿using FoodOrderingApp.Views;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodOrderingApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            ///MainPage = new LoginView();
            //MainPage = new NavigationPage(new SettingsPage());
            string uname = Preferences.Get("Username", String.Empty);
            if (String.IsNullOrEmpty(uname))
            {
                MainPage = new LoginView();
            }
            else
            {
                MainPage = new ProductView();
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

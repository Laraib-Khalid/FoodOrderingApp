﻿using FoodOrderingApp.Models;
using FoodOrderingApp.Services;
using FoodOrderingApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace FoodOrderingApp.ViewModels
{
    public class ProductsViewModel : BaseViewModel
    {
        private string _UserName;

        public string UserName
        {
            set
            {
                _UserName = value;
                OnPropertyChanged();
            }
            get 
            {
                return _UserName; 
            }
        }

        private int _UserCartItemsCount;

        public int UserCartItemsCount
        {
            set 
            {
                _UserCartItemsCount = value;
                OnPropertyChanged();
            }
            get 
            {
                return _UserCartItemsCount; 
            }
        }

        public ObservableCollection<Category> Categories { get; set; }
        public ObservableCollection<FoodItem> LatestItems { get; set; }
        
        public Command ViewCartCommand { get; set; }
        public Command LogoutCommand { get; set; }

        public ProductsViewModel()
        {
            var uname = Preferences.Get("Username", string.Empty);
            if(String.IsNullOrEmpty(uname))
            {
                UserName = "Guest";
            }
            else
            {
                UserName = uname;
            }
            UserCartItemsCount = new CartItemService().GetUserCartCount();
            Categories = new ObservableCollection<Category>();
            LatestItems = new ObservableCollection<FoodItem>();

            ViewCartCommand = new Command(async () => await ViewCartAsync());
            LogoutCommand = new Command(async () => await LogoutAsync());

            GetCategories();
            GetLatestItems();
        }

        private async Task ViewCartAsync()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new CartView());
        }

        private async Task LogoutAsync()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new LogoutView());
        }

        private async void GetCategories()
        {
            var data = await new CategoryDataService().GetCategoriesAsync();
            Categories.Clear();
            foreach (var item in data)
            {
                Categories.Add(item);
            }
        }

        private async void GetLatestItems()
        {
            var data = await new FoodItemService().GetLatestFoodItemsAsync();
            LatestItems.Clear();
            foreach (var item in data)
            {
                LatestItems.Add(item);
            }
        }
    }
}

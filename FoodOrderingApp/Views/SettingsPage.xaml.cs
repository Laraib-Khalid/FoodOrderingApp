﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodOrderingApp.Helpers;
using FoodOrderingApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodOrderingApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();
        }

        private async void ButtonCategories_Clicked(object sender, EventArgs e)
        {
            var acd = new AddCategoryData();
            await acd.AddCategoriesAsync();
        }

        private async void ButtonProducts_Clicked(object sender, EventArgs e)
        {
            var afd = new AddFoodItemData();
            await afd.AddFoodItemAsync();
        }

        private void ButtonCart_Clicked(object sender, EventArgs e)
        {
            var cct = new CreateCartTable();
            if(cct.CreateTable())
            {
                DisplayAlert("Success", "Cart Table Created", "OK");
            }
            else
            {
                DisplayAlert("Error", "Error while creating table", "OK");
            }
        }
    }
}
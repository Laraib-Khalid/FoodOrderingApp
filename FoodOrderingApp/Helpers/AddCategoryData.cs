﻿using Firebase.Database;
using Firebase.Database.Query;
using FoodOrderingApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FoodOrderingApp.Helpers
{
    public class AddCategoryData
    {
        public List<Category> Categories { get; set; }
        FirebaseClient client;
        public AddCategoryData()
        {
            client = new FirebaseClient("https://foodorderingapp-6f59e-default-rtdb.firebaseio.com/");
            Categories = new List<Category>()
            {
                new Category()
                {
                    CategoryID = 1,
                    CategoryName = "Burger",
                    CategoryPoster = "MainBurger.jpg",
                    ImageUrl = "Burger.png"
                },
                new Category()
                {
                    CategoryID = 2,
                    CategoryName = "Pizza",
                    CategoryPoster = "MainPizza.jpg",
                    ImageUrl = "Pizza.png"
                },
                new Category()
                {
                    CategoryID = 3,
                    CategoryName = "Desserts",
                    CategoryPoster = "MainDessert.jpg",
                    ImageUrl = "Dessert.png"
                },
                new Category()
                {
                    CategoryID = 4,
                    CategoryName = "Veg Burger",
                    CategoryPoster = "MainBurger.jpg",
                    ImageUrl = "Burger.png"
                },
                new Category()
                {
                    CategoryID = 5,
                    CategoryName = "Veg Pizza",
                    CategoryPoster = "MainPizza.jpg",
                    ImageUrl = "Pizza.png"
                },
                new Category()
                {
                    CategoryID = 6,
                    CategoryName = "Cakes",
                    CategoryPoster = "MainDessert.jpg",
                    ImageUrl = "Dessert.png"
                }

            };
        }
        public async Task AddCategoriesAsync()
        {
            try
            {
                foreach(var category in Categories)
                {
                    await client.Child("Categories").PostAsync(new Category()
                    {
                        CategoryID = category.CategoryID,
                        CategoryName = category.CategoryName,
                        CategoryPoster = category.CategoryPoster,
                        ImageUrl = category.ImageUrl
                    });
                }
            }
            catch(Exception ex)
            {
               await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }
}

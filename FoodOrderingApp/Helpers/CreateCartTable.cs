using FoodOrderingApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FoodOrderingApp.Helpers
{
    public class CreateCartTable
    {
        public bool CreateTable()
        {
            try
            {
                var conn = DependencyService.Get<ISQLite>().GetConnection();
                conn.CreateTable<CartItem>();
                conn.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using FoodOrderingApp.Droid;
using FoodOrderingApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xamarin.Forms;

[assembly:Dependency(typeof(SQLite_Android))]
namespace FoodOrderingApp.Droid
{
    public class SQLite_Android : ISQLite
    {
        public SQLiteConnection GetConnection()
        {
             var sqliteFileName = "MyDatabase.db3";
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, sqliteFileName);
            var conn = new SQLiteConnection(path);
            return conn;
        }
    }
}
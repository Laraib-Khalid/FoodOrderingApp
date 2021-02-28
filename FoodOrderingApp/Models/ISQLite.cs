using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace FoodOrderingApp.Models
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}

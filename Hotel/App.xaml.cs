using Hotel.Models.DataAccesLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Hotel
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            //the first query in the app is used to generate and cache the model
            // represented by the context, we do it here so app doesn't freeze up as
            // result of user action
            using (var context = new HotelDBContext())
            {
                context.Admins.Find(0);
            }

            base.OnStartup(e);
        }        
    }
}

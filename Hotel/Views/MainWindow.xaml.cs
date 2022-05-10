using Hotel.Models.DataAccesLayer;
using Hotel.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hotel.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private readonly HotelDBContext _context = new HotelDBContext();

        // populate the db with some data
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //// create an admin
            //Admin admin = new Admin
            //{
            //    Email = "mocanu.alexandra@adminhotel.com",
            //    Password = "admin1234",
            //    IsActive = true
            //};
            //// add the admin to the db
            //_context.Admins.Add(admin);

            //// create a guest
            //Guest guest = new Guest
            //{
            //    Username = "MocanuDaria",
            //    Password = "octombrie2004",
            //    FirstName = "Daria",
            //    LastName = "Mocanu",
            //    Phone = "0723456789",
            //    IsActive = true
            //};
            //// add the guest to the db
            //_context.Guests.Add(guest);

            // save the changes
            _context.SaveChanges();

            if (DataContext is Utils.Utility.ICloseWindows viewModel)
                viewModel.Close += () => { this.Close(); };
        }
    }
}

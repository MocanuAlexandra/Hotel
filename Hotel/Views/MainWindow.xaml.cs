using Hotel.Models.DataAccesLayer;
using Hotel.Models.EntityLayer;
using Hotel.Utils;
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
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            using (var _context = new HotelDBContext())
            {

                //// create an admin
                //Admin admin = new Admin
                //{
                //    Email = "mocanu.alexandra@adminhotel.com",
                //    Password = Utility.HashPassword("admin1234"),
                //    IsActive = true
                //};
                //// add the admin to the db
                //_context.Admins.Add(admin);


                ////create an employee
                //Employee employee = new Employee
                //{
                //    Email = "muntean.raluca@employee-hotel.com",
                //    Password = Utility.HashPassword("employee1234"),
                //    IsActive = true
                //};
                //_context.Employees.Add(employee);

                // save the changes
                _context.SaveChanges();
            }
            
            
            if (DataContext is Utils.Utility.ICloseWindows viewModel)
                viewModel.Close += () => { this.Close(); };
        }

    }
}

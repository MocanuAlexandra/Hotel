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
using System.Windows.Shapes;

namespace Hotel.Views.Admin_Views
{
    /// <summary>
    /// Interaction logic for AssignHotelServiceWindow.xaml
    /// </summary>
    public partial class AssignHotelServiceWindow : Window
    {
        public AssignHotelServiceWindow()
        {
            InitializeComponent();
            Loaded += Window_Loaded;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (DataContext is Utils.Utility.ICloseWindows viewModel)
                viewModel.Close += () => { this.Close(); };
        }
    }
}


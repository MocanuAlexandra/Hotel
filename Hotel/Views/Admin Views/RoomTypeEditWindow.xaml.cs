using Hotel.ViewModels;
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
    /// Interaction logic for AddRoomType.xaml
    /// </summary>
    public partial class RoomTypeEditWindowView : Window
    {
        public RoomTypeEditWindowView()
        {
            InitializeComponent();
            Loaded += RoomTypeEdit_Loaded;
        }

        private void RoomTypeEdit_Loaded(object sender, RoutedEventArgs e)
        {
            if (DataContext is Utils.Utility.ICloseWindows viewModel)
                viewModel.Close += () => { this.Close(); };
        }
    }
}

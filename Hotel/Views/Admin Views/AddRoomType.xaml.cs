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
    public partial class AddRoomType : Window
    {
        public AddRoomType(AdminStartVM parentViewModel)
        {
            InitializeComponent();
            
            ((AddRoomTypeVM)DataContext).AdminStartVM = parentViewModel;
            Loaded += AddRoomType_Loaded;
        }

        private void AddRoomType_Loaded(object sender, RoutedEventArgs e)
        {
            if (DataContext is Utils.Utility.ICloseWindows viewModel)
                viewModel.Close += () => { this.Close(); };
        }
    }
}

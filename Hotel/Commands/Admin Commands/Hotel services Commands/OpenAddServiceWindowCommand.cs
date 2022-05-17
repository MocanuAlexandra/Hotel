using Hotel.ViewModels;
using Hotel.ViewModels.Admin_ViewModels;
using Hotel.Views.Admin_Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Commands.Admin_Commands.Hotel_services_Commands
{
    public class OpenAddServiceWindowCommand:BaseCommand
    {
        private readonly AdminMainVM _adminStartVM;
        public OpenAddServiceWindowCommand(AdminMainVM adminStartVM)
        {
            _adminStartVM = adminStartVM;
        }

        public override void Execute(object parameter)
        {
            HotelServiceEditWindow hotelServiceEditWindowView = new HotelServiceEditWindow()
            {
                DataContext = new HotelServiceEditVM(_adminStartVM,
                HotelServiceEditVM.HotelServiceEditMode.Add)
            };
            hotelServiceEditWindowView.ShowDialog();
        }
    }
}

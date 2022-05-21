using Hotel.ViewModels;
using Hotel.ViewModels.Admin_View_Models;
using Hotel.Views.Admin_Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Commands.Admin_Commands.Hotel_services_Commands
{
    public class OpenAssignHotelServiceCommand:BaseCommand
    {
        private readonly AdminMainVM _adminStartVM;
        public OpenAssignHotelServiceCommand(AdminMainVM adminStartVM)
        {
            _adminStartVM = adminStartVM;
        }

        public override void Execute(object parameter)
        {
            AssignHotelServiceWindow hotelServiceWindow = new AssignHotelServiceWindow()
            {
                DataContext = new AssignHotelServiceToOfferVM(_adminStartVM)
            };
            hotelServiceWindow.ShowDialog();
        }
    }
}

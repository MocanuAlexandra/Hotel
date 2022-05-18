using Hotel.ViewModels;
using Hotel.ViewModels.Admin_ViewModels;
using Hotel.Views.Admin_Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Commands.Admin_Commands.Room_Facilities_Commands
{
    public class OpenAssignRoomFacilityCommand:BaseCommand
    {
        private readonly AdminMainVM _adminStartVM;
        public OpenAssignRoomFacilityCommand(AdminMainVM adminStartVM)
        {
            _adminStartVM = adminStartVM;
        }

        public override void Execute(object parameter)
        {
            AssignRoomFacilityWindow roomFacilityWindowView = new AssignRoomFacilityWindow()
            {
                DataContext = new AssignRoomFacilityVM(_adminStartVM)
            };
            roomFacilityWindowView.ShowDialog();
        }
    }
}


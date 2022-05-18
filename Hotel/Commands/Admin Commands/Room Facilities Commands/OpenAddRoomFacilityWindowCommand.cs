using Hotel.ViewModels;
using Hotel.ViewModels.Admin_ViewModels;
using Hotel.Views.Admin_Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Commands.Admin_Commands.RoomFacilities_Commands
{
    public class OpenAddRoomFacilityWindowCommand:BaseCommand
    {
        private readonly AdminMainVM _adminStartVM;
        public OpenAddRoomFacilityWindowCommand(AdminMainVM adminStartVM)
        {
            _adminStartVM = adminStartVM;
        }

        public override void Execute(object parameter)
        {
            RoomFacilityEditWindow roomFacilityEditWindowView = new RoomFacilityEditWindow()
            {
                DataContext = new RoomFacilityEditVM(_adminStartVM,
                RoomFacilityEditVM.RoomFacilityEditMode.Add)
            };
            roomFacilityEditWindowView.ShowDialog();
        }
    }
}


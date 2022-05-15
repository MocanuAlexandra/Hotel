using Hotel.Views.Admin_Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.ViewModels.Commands.Admin_Commands
{
    public class OpenAddRoomTypeWindowCommand : BaseCommand
    {
        private readonly AdminMainVM _adminStartVM;
        public OpenAddRoomTypeWindowCommand(AdminMainVM adminStartVM)
        {
            _adminStartVM = adminStartVM;
        }

        public override void Execute(object parameter)
        {
            RoomTypeEditWindowView roomTypeEditWindowView = new RoomTypeEditWindowView()
            {
                DataContext = new RoomTypeEditVM(_adminStartVM,
                RoomTypeEditVM.RoomTypeEditMode.Add)
            };
            roomTypeEditWindowView.ShowDialog();
        }     
    }
}

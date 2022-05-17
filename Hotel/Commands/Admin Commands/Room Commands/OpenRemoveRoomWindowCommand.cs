using Hotel.ViewModels;
using Hotel.Views.Admin_Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Commands.Admin_Commands.Room_Commands
{
    public class OpenRemoveRoomWindowCommand:BaseCommand
    {
        private readonly AdminMainVM _adminViewModel;
        public OpenRemoveRoomWindowCommand(AdminMainVM adminViewModel)
        {
            _adminViewModel = adminViewModel;
        }

        public override void Execute(object parameter)
        {
            RemoveRoomWindow removeRoomWindowView = new RemoveRoomWindow()
            {
                DataContext = new RemoveRoomVM(_adminViewModel)
            };
            removeRoomWindowView.ShowDialog();
        }
    }
}



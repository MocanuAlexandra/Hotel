using Hotel.ViewModels;
using Hotel.Views.Admin_Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Commands.Admin_Commands.Room_Commands
{
    public class OpenAddRoomWindowCommand:BaseCommand
    {
        private readonly AdminMainVM _adminViewModel;
        public OpenAddRoomWindowCommand(AdminMainVM adminViewModel)
        {
            _adminViewModel = adminViewModel;
        }

        public override void Execute(object parameter)
        {
            AddRoomWindow addRoomWindowView = new AddRoomWindow()
            {
                DataContext = new AddRoomVM(_adminViewModel)
            };
            addRoomWindowView.ShowDialog();
        }
    }
}


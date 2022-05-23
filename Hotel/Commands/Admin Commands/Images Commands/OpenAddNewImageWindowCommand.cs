using Hotel.ViewModels;
using Hotel.Views.Admin_Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Commands.Admin_Commands.Images_Commands
{
    public class OpenAddNewImageWindowCommand:BaseCommand
    {
        private readonly AdminMainVM _adminViewModel;
        public OpenAddNewImageWindowCommand(AdminMainVM adminViewModel)
        {
            _adminViewModel = adminViewModel;
        }

        public override void Execute(object parameter)
        {
            AddNewImageWindow addImageWindowView = new AddNewImageWindow()
            {
                DataContext = new RoomImageEditVM(_adminViewModel)
            };
            addImageWindowView.ShowDialog();
        }
    }
}


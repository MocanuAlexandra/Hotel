using Hotel.Views.Admin_Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.ViewModels.Commands
{
    public class OpenAddRoomTypeWindowCommand : BaseCommand
    {
        private readonly AdminStartVM _adminStartVM;
        public OpenAddRoomTypeWindowCommand(AdminStartVM adminStartVM)
        {
            _adminStartVM = adminStartVM;
        }

        public override void Execute(object parameter)
        {
            AddRoomType addRoomType = new AddRoomType(_adminStartVM);
            addRoomType.ShowDialog();
        }
    }
}

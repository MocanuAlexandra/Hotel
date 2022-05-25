using Hotel.Utils;
using Hotel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Commands.Navigation_Commands
{
    public class GuestViewCommand:BaseCommand
    {
        private readonly MainWindowVM _mainWindowVM;
        public GuestViewCommand(MainWindowVM mainWindowVM)
        {
            _mainWindowVM = mainWindowVM;
        }

        public override void Execute(object parameter)
        {
            if (parameter is StartVM)
            {
                _mainWindowVM.CurrentViewModel = new GuestWindowVM();
                _mainWindowVM.CurrentHeight = Constants.ClientWindowSize.windowHeight;
                _mainWindowVM.CurrentWidth = Constants.ClientWindowSize.windowWidth;
            }
        }
    }
}

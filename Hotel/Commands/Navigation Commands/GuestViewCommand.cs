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
            var signInVM = parameter as StartVM;
            if (parameter is StartVM)
            {
                _mainWindowVM.CurrentViewModel = new GuestWindowVM();
                _mainWindowVM.CurrentHeight = Constants.DefaultWindowSize.windowHeight;
                _mainWindowVM.CurrentWidth = Constants.DefaultWindowSize.windowWidth;
            }
        }
    }
}

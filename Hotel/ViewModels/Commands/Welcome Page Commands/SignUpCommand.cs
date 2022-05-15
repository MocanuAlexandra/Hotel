using Hotel.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.ViewModels.Commands
{
    public class SignUpCommand : BaseCommand
    {
        private readonly MainWindowVM _mainWindowViewModel;
        public SignUpCommand(MainWindowVM mainWindowViewModel)
        {
            _mainWindowViewModel = mainWindowViewModel;
        }
        public override void Execute(object parameter)
        {
            if (parameter is StartVM)
            {
                _mainWindowViewModel.CurrentViewModel = new SignUpVM();

                _mainWindowViewModel.CurrentWidth = Constants.SignUpWindowSize.windowWidth;
                _mainWindowViewModel.CurrentHeight = Constants.SignUpWindowSize.windowHeight;
            }
        }
    }
}
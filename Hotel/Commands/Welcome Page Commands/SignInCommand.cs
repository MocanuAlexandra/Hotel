using Hotel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Commands.Welcome_Page_Commands
{
    public class SignInCommand:BaseCommand
    {
        private readonly MainWindowVM _mainWindowViewModel;
        public SignInCommand(MainWindowVM mainWindowViewModel)
        {
            _mainWindowViewModel = mainWindowViewModel;
        }
        public override void Execute(object parameter)
        {
            if (parameter is StartVM)
            {
                _mainWindowViewModel.CurrentViewModel = new SignInVM();
            }
        }
    }
}

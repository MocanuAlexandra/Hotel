using Hotel.Utils;
using Hotel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Commands.Navigation_Commands
{
    public class LogoutCommand : BaseCommand
    {
        private readonly MainWindowVM _mainWindowViewModel;
        public LogoutCommand(MainWindowVM mainWindowViewModel)
        {
            _mainWindowViewModel = mainWindowViewModel;
        }

        public override void Execute(object parameter)
        {
            //if we execute LogoutCommand from SignUpView
            if (parameter is SignUpVM )
            {
                _mainWindowViewModel.CurrentViewModel = new StartVM();

                _mainWindowViewModel.CurrentWidth = Constants.DefaultWindowSize.windowWidth;
                _mainWindowViewModel.CurrentHeight = Constants.DefaultWindowSize.windowHeight;
            }

            //if we execute LogoutCommand from SignInView
            if (parameter is SignInVM)
            {
                _mainWindowViewModel.CurrentViewModel = new StartVM();

                _mainWindowViewModel.CurrentWidth = Constants.DefaultWindowSize.windowWidth;
                _mainWindowViewModel.CurrentHeight = Constants.DefaultWindowSize.windowHeight;
            }

            // if we execute logout from AdminMainView
            if (parameter is AdminMainVM)
            {
                _mainWindowViewModel.CurrentViewModel = new StartVM();

                _mainWindowViewModel.CurrentWidth = Constants.DefaultWindowSize.windowWidth;
                _mainWindowViewModel.CurrentHeight = Constants.DefaultWindowSize.windowHeight;
            }

            //if we execute logout from Guest window
            if (parameter is GuestWindowVM)
            {
                _mainWindowViewModel.CurrentViewModel = new StartVM();

                _mainWindowViewModel.CurrentWidth = Constants.DefaultWindowSize.windowWidth;
                _mainWindowViewModel.CurrentHeight = Constants.DefaultWindowSize.windowHeight;
            }

            //if we execute logout from client window
            if (parameter is ClientMainVM)
            {
                _mainWindowViewModel.CurrentViewModel = new StartVM();

                _mainWindowViewModel.CurrentWidth = Constants.DefaultWindowSize.windowWidth;
                _mainWindowViewModel.CurrentHeight = Constants.DefaultWindowSize.windowHeight;
            }
        }
    }
}

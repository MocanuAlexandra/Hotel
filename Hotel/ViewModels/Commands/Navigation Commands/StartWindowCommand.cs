using Hotel.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.ViewModels.Commands
{
    public class StartWindowCommand : BaseCommand
    {
        private readonly MainWindowVM _mainWindowViewModel;
        public StartWindowCommand(MainWindowVM mainWindowViewModel)
        {
            _mainWindowViewModel = mainWindowViewModel;
        }

        public override void Execute(object parameter)
        {
            //if we execute StartWindowCommand from SignUpView
            if (parameter is SignUpVM )
            {
                _mainWindowViewModel.CurrentViewModel = new StartVM();

                _mainWindowViewModel.CurrentWidth = Constants.DefaultWindowSize.windowWidth;
                _mainWindowViewModel.CurrentHeight = Constants.DefaultWindowSize.windowHeight;
            }

            //if we execute StartWindowCommand from SignInView
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
        }
    }
}

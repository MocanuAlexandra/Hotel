using Hotel.Utils;
using Hotel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Commands.Navigation_Commands
{
    public class BackToMainVMCommand : BaseCommand
    {
        private readonly MainWindowVM _mainWindowViewModel;
        public BackToMainVMCommand(MainWindowVM mainWindowViewModel)
        {
            _mainWindowViewModel = mainWindowViewModel;
        }

        public override void Execute(object parameter)
        {
            //if we execute Back from ViewBookinsHistory
            if (parameter is ViewBookingsHistoryVM)
            {
                ViewBookingsHistoryVM viewBookingsHisotry = parameter as ViewBookingsHistoryVM;
                _mainWindowViewModel.CurrentViewModel = new ClientMainVM()
                {
                    Client = viewBookingsHisotry.Client,
                    MainWindowVM = _mainWindowViewModel
                };

                _mainWindowViewModel.CurrentWidth = Constants.ClientWindowSize.windowWidth;
                _mainWindowViewModel.CurrentHeight = Constants.ClientWindowSize.windowHeight;
            }           
        }
    }
}

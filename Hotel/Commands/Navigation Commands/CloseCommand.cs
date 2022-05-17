using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Hotel.Utils.Utility;

namespace Hotel.Commands.Navigation_Commands
{
    internal class CloseCommand:BaseCommand
    {
        private readonly ICloseWindows _closeWindowsViewModel;
        public CloseCommand(ICloseWindows closeWindowsViewModel)
        {
            _closeWindowsViewModel = closeWindowsViewModel;
        }

        public override void Execute(object parameter)
        {
            _closeWindowsViewModel?.CloseWindow();
        }
    }
}
﻿using Hotel.ViewModels;
using Hotel.Views.Client_Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Commands.Client_Commands
{
    public class OpenMakeBookingCommand : BaseCommand
    {
        private readonly ClientMainVM _clientViewModel;
        public OpenMakeBookingCommand(ClientMainVM clientViewModel)
        {
            _clientViewModel = clientViewModel;
        }

        public override void Execute(object parameter)
        {
            new MakeBookingWindow()
            {
                DataContext = new MakeBookingVM(_clientViewModel.Client)
                {
                    ClientMainVM = _clientViewModel
                }
            }.Show();
        }
    }
}

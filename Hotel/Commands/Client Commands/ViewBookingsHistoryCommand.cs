using Hotel.Models.DataAccessLayer;
using Hotel.Models.EntityLayer;
using Hotel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Commands.Client_Commands
{
    public class ViewBookingsHistoryCommand : BaseCommand
    {
        private readonly ClientMainVM _clientMainVM;
        public ViewBookingsHistoryCommand(ClientMainVM clientMainVM)
        {
            _clientMainVM = clientMainVM;
        }

        public override void Execute(object parameter)
        {
            _clientMainVM.MainWindowVM.CurrentViewModel =
                new ViewBookingsHistoryVM(_clientMainVM.MainWindowVM)
                {
                    Client = _clientMainVM.Client,
                    ReservationOffers = ReservationOfferDAL.GetReservations(_clientMainVM.Client._client)
                };           
        }
    }
}

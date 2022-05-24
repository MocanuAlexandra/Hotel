using Hotel.Models.DataAccessLayer;
using Hotel.Models.EntityLayer;
using Hotel.ViewModels.Model_Wrappers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Hotel.Commands.Employee_Commands;

namespace Hotel.ViewModels
{
    public class ViewAllBookingsVM:BaseViewModel
    {
        #region Properties
        public MainWindowVM MainWindowVM { get; set; }
        public ObservableCollection<ReservationOfferVM> ReservationOffers { get; set; }

        private ReservationOfferVM _selectedReservationOffer;
        public ReservationOfferVM SelectedReservationOffer
        {
            get { return _selectedReservationOffer; }
            set
            {
                _selectedReservationOffer = value;
                OnPropertyChanged("SelectedReservationOffer");
            }
        }
        public ObservableCollection<BookingVM> Bookings { get; set; }
        private BookingVM _selectedBooking;
        public BookingVM SelectedBooking
        {
            get { return _selectedBooking; }
            set
            {
                _selectedBooking = value;
                OnPropertyChanged("SelectedBooking");
            }
        }

        #endregion
        
        #region Commands
        public ICommand SetStatusResOfferCommand { get; set; }

        public ICommand SetStatusResCommand { get; set; }

        #endregion
        
        public ViewAllBookingsVM(MainWindowVM mainWindowVM)
        {
            MainWindowVM = mainWindowVM;

            // read the bookings with offer, create wrapers and populate the list
            ReservationOffers = new ObservableCollection<ReservationOfferVM>();
            foreach (var resOffer in ReservationOfferDAL.GetAllReservations())
                ReservationOffers.Add(new ReservationOfferVM(resOffer));

            // read the bookings without offer, create wrapers and populate the list
            Bookings = new ObservableCollection<BookingVM>();
            foreach (var booking in BookingDAL.GetAllBookings())
                Bookings.Add(new BookingVM(booking));

            // commands
            SetStatusResOfferCommand = new SetStatusResOfferCommand(this);
            SetStatusResCommand = new SetStatusResCommand(this);
        }
    }
}

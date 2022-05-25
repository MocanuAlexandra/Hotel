using Hotel.Commands.Employee_Commands;
using Hotel.Models.DataAccessLayer;
using Hotel.ViewModels.Model_Wrappers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Hotel.ViewModels
{
    public class EmployeeMainVM : BaseViewModel
    {
        #region Properties
        public MainWindowVM MainWindowVM { get; set; }
        
        public ObservableCollection<RoomTypeVM> RoomTypes { get; set; }
        public ObservableCollection<RoomImageVM> Images { get; set; }

        private DateTime _startDate;
        public DateTime StartDate
        {
            get { return _startDate; }
            set { _startDate = value; OnPropertyChanged(); }
        }

        private double _noOfNights;
        public double NoOfNights
        {
            get { return _noOfNights; }
            set { _noOfNights = value; OnPropertyChanged(); }
        }

        #endregion

        #region Commands
        public ICommand SearchCommand { get; private set; }
        public ICommand ViewBookingsEmployeeCommand { get; private set; }
        #endregion

        public EmployeeMainVM()
        {
            StartDate = DateTime.Today;

            SearchCommand = new EmployeeSearchCommand(this);
            ViewBookingsEmployeeCommand = new ViewBookingsEmployeeCommand(this);

            // read the room types, create wrapers and populate the list
            RoomTypes = new ObservableCollection<RoomTypeVM>();
            foreach (var roomType in RoomTypeDAL.GetRoomTypes())
                RoomTypes.Add(new RoomTypeVM(roomType));

            // read the images, create wrapers and populate the list
            Images = new ObservableCollection<RoomImageVM>();
            foreach (var image in ImageRoomDAL.GetAllImages())
                Images.Add(new RoomImageVM(image));
        }
    }
}

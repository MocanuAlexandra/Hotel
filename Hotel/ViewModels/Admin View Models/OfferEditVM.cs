using Hotel.Commands.Admin_Commands.Offers_Commands.CRUD_Offer_Commands;
using Hotel.Commands.Navigation_Commands;
using Hotel.Models.EntityLayer;
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
    public class OfferEditVM : BaseViewModel, Utils.Utility.ICloseWindows
    {
        public ObservableCollection<RoomTypeVM> RoomTypes { get; set; }

        public enum OfferEditMode
        {
            Add,
            Edit
        }

        public AdminMainVM AdminMainVM { get; set; }
        public OfferEditMode Mode { get; set; }

        //displays create if the window is opened in create mode, or edit if it is opened in edit mode
        public string SubmitButtonContent => Mode.ToString();

        #region Properties

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        private RoomTypeVM _selectedRoomType;
        public RoomTypeVM SelectedRoomType
        {
            get { return _selectedRoomType; }
            set
            {
                _selectedRoomType = value;
                OnPropertyChanged();
            }
        }

        private string _price;
        public string Price
        {
            get { return _price; }
            set { _price = value; OnPropertyChanged(); }
        }

        private DateTime _startDate;
        public DateTime StartDate
        {
            get { return _startDate; }
            set { _startDate = value; OnPropertyChanged(); }
        }

        private DateTime _endDate;
        public DateTime EndDate
        {
            get { return _endDate; }
            set { _endDate = value; OnPropertyChanged(); }
        }
        #endregion

        #region Commands
        public ICommand SubmitOfferCommand { get; private set; }
        public ICommand CloseCommand { get; private set; }
        #endregion

        public OfferEditVM(AdminMainVM adminMainVM, OfferEditMode mode)
        {
            AdminMainVM = adminMainVM;
            Mode = mode;

            RoomTypes = AdminMainVM.RoomTypes;

            StartDate = DateTime.Today;
            EndDate = DateTime.Today.AddDays(1);

            SubmitOfferCommand = new SubmitOfferCommand(this);
            CloseCommand = new CloseCommand(this);

            //if we're in the edit mode we need to populate the fields with the offer's data
            if (mode == OfferEditMode.Edit)
            {
                Name = AdminMainVM.SelectedOffer.Description;
                SelectedRoomType = new RoomTypeVM(AdminMainVM.SelectedOffer.AssignedRoomType);
                Price = AdminMainVM.SelectedOffer.Price.ToString();
                StartDate = AdminMainVM.SelectedOffer.CheckInDate;
                EndDate = AdminMainVM.SelectedOffer.CheckOutDate;
            }
        }

        public Action Close { get; set; }
        public void CloseWindow()
        {
            //if the close action has subscribers, it calls them, closing the 
            //windows that use this viewModel 
            Close?.Invoke();
        }
    }
}

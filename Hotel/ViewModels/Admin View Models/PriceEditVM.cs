using Hotel.Commands.Admin_Commands.Room_Type_Commands.Price_Edit_Commands;
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

namespace Hotel.ViewModels
{
    public class PriceEditVM : BaseViewModel
    {
        //parent viewModel that contains the room type to which we add or edit the price
        public RoomTypeEditVM RoomTypeEditViewModel { get; private set; }

        #region Properties
        
        //prices associated to the room type
        public ObservableCollection<PriceVM> Prices { get; set; }

        private PriceVM _selectedPrice;
        public PriceVM SelectedPrice
        {
            get { return _selectedPrice; }
            set
            {
                _selectedPrice = value;
                PriceValue = _selectedPrice.Value.ToString();
                Description = _selectedPrice.Description;
                ValabilityStartDate = _selectedPrice.ValabilityStartDate;
                ValabilityEndDate = _selectedPrice.ValabilityEndDate;

                OnPropertyChanged();
            }
        }

        //we need separate fields so that the save does not overwrite the selected price
        //unless the edit button has been pressed
        private string _priceValue;
        private string _description;
        private DateTime _valabilityStartDate;
        private DateTime _valabilityEndDate;
        public string PriceValue
        {
            get { return _priceValue; }
            set
            {
                _priceValue = value;
                OnPropertyChanged();
            }
        }
        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged();
            }
        }
        public DateTime ValabilityStartDate
        {
            get { return _valabilityStartDate; }
            set
            {
                _valabilityStartDate = value;
                OnPropertyChanged();
            }
        }
        public DateTime ValabilityEndDate
        {
            get { return _valabilityEndDate; }
            set
            {
                _valabilityEndDate = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Commands
        public ICommand SubmitPriceCommand { get; private set; }
        public ICommand DeletePriceCommand { get; private set; }
        #endregion

        public PriceEditVM(RoomTypeEditVM roomTypeEditViewModel)
        {
            RoomTypeEditViewModel = roomTypeEditViewModel;

            SubmitPriceCommand = new SubmitPriceCommand(this);
            DeletePriceCommand = new DeletePriceCommand(this);

            //if the room type is being edited, we need to load the prices
            //if not, we need to create a new collection and just add the dummy price
            Prices = new ObservableCollection<PriceVM>
            {
                new PriceVM(new Price()
                {
                    Description = "New",
                    IsActive = true,
                    ValabilityStartDate = DateTime.Today,
                    ValabilityEndDate = DateTime.Today.AddDays(1),
                })
            };

            if (RoomTypeEditViewModel.Mode == RoomTypeEditVM.RoomTypeEditMode.Edit)
            {
                foreach (var price in PriceDAL.GetPricesForRoom(
                    RoomTypeEditViewModel.AdminMainVM.SelectedRoomType.Id))
                {
                    Prices.Add(new PriceVM(price));
                }
            }
            SelectedPrice = Prices.FirstOrDefault();
        }
    }
}

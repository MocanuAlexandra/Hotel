using Hotel.Commands.Admin_Commands.Hotel_services_Commands.CRUD_Hotel_services_Commands;
using Hotel.Commands.Navigation_Commands;
using Hotel.ViewModels.Model_Wrappers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Hotel.ViewModels.Admin_View_Models
{
    public class AssignHotelServiceToOfferVM : BaseViewModel, Utils.Utility.ICloseWindows
    {
        public ObservableCollection<HotelServicesVM> HotelServices { get; set; }
        public ObservableCollection<OfferVM> Offers { get; set; }

        public AdminMainVM AdminMainVM { get; set; }

        private HotelServicesVM _selectedHotelService;
        public HotelServicesVM SelectedHotelService
        {
            get { return _selectedHotelService; }
            set
            {
                _selectedHotelService = value;
                OnPropertyChanged("SelectedHotelService");
            }
        }

        private OfferVM _selectedOffer;
        public OfferVM SelectedOffer
        {
            get { return _selectedOffer; }
            set
            {
                _selectedOffer = value;
                OnPropertyChanged("SelectedOffer");
            }
        }

        #region Commands
        public ICommand AssignCommand { get; private set; }
        public ICommand CloseCommand { get; private set; }
        #endregion

        public AssignHotelServiceToOfferVM(AdminMainVM adminMainVM)
        {
            AdminMainVM = adminMainVM;
            HotelServices = new ObservableCollection<HotelServicesVM>(adminMainVM.HotelServices);
            Offers = new ObservableCollection<OfferVM>(adminMainVM.Offers);

            AssignCommand = new AssignHotelServiceToOfferCommand(this);
            CloseCommand = new CloseCommand(this);
        }

        public Action Close { get; set; }
        public void CloseWindow()
        {
            //if the close action has subscribers, it calls them, closing the 
            //windows that use this viewModel (see MainWindow code-behind)
            Close?.Invoke();
        }
    }
}

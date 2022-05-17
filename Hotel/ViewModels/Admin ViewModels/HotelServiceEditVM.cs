using Hotel.Commands.Admin_Commands.Hotel_services_Commands;
using Hotel.Commands.Navigation_Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Hotel.ViewModels.Admin_ViewModels
{
    public class HotelServiceEditVM:BaseViewModel, Utils.Utility.ICloseWindows
    {

        public enum HotelServiceEditMode
        {
            Add,
            Edit
        }

        public AdminMainVM AdminMainVM { get; private set; }
        public HotelServiceEditMode Mode { get; set; }

        //displays create if the window is opened in create mode, or edit if it is opened in edit mode
        public string SubmitButtonContent => Mode.ToString();

        #region Hotel Service Properties
        private string _hotelServiceName;

        public string HotelServiceName
        {
            get { return _hotelServiceName; }
            set { _hotelServiceName = value; OnPropertyChanged(); }
        }
        #endregion

        #region Commands
        public ICommand SubmitHotelServiceCommand { get; private set; }
        public ICommand CloseCommand { get; private set; }
        #endregion

        public HotelServiceEditVM(AdminMainVM adminMainVM, HotelServiceEditMode mode)
        {
            AdminMainVM = adminMainVM;
            Mode = mode;
            SubmitHotelServiceCommand = new SubmitHotelServiceCommand(this);
            CloseCommand = new CloseCommand(this);

            //if we're in the edit mode we need to populate the fields with the room type's data
            if (mode == HotelServiceEditMode.Edit)
            {
                HotelServiceName = AdminMainVM.SelectedHotelService.Name;
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
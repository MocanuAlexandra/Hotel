using Hotel.Commands.Admin_Commands.Room_Type_Commands.RoomFacilities_Commands;
using Hotel.Commands.Navigation_Commands;
using Hotel.ViewModels.Model_Wrappers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Hotel.ViewModels.Admin_ViewModels
{
    public class RoomFacilityEditVM : BaseViewModel, Utils.Utility.ICloseWindows
    {

        public enum RoomFacilityEditMode
        {
            Add,
            Edit
        }
        public AdminMainVM AdminMainVM { get; private set; }
        public RoomFacilityEditMode Mode { get; private set; }

        //displays create if the window is opened in create mode, or edit if it is opened in edit mode
        public string SubmitButtonContent => Mode.ToString();

        #region Properties
        private string _facilityName;
        public string FacilityName
        {
            get { return _facilityName; }
            set
            {
                _facilityName = value;
                OnPropertyChanged();
            }
        }

        #endregion
        
        #region Commands
        public ICommand SubmitRoomFacilityCommand { get; private set; }
        public ICommand CloseCommand { get; private set; }
        #endregion

        public RoomFacilityEditVM(AdminMainVM adminViewModel, RoomFacilityEditMode mode)
        {
            AdminMainVM = adminViewModel;
            Mode = mode;

            SubmitRoomFacilityCommand = new SubmitRoomFacilityCommand(this);
            CloseCommand = new CloseCommand(this);

            //if we're in the edit mode we need to populate the fields with the room type's data
            if (mode == RoomFacilityEditMode.Edit)
            {
                FacilityName = AdminMainVM.SelectedFacility.Name;                
            }
        }

        #region Methods
        public Action Close { get; set; }
        public void CloseWindow()
        {
            //if the close action has subscribers, it calls them, closing the 
            //windows that use this viewModel (see MainWindow code-behind)
            Close?.Invoke();
        }
        #endregion
    }
}



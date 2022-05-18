using Hotel.Commands.Admin_Commands.Room_Facilities_Commands.CRUD_RoomFacilities_Commands;
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
    public class AssignRoomFacilityVM : BaseViewModel, Utils.Utility.ICloseWindows
    {
        public ObservableCollection<RoomTypeVM> RoomTypes { get; set; }
        public ObservableCollection<FacilityVM> Facilities { get; set; }

        AdminMainVM AdminMainVM { get; set; }

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

        private FacilityVM _selectedFacility;
        public FacilityVM SelectedFacility
        {
            get { return _selectedFacility; }
            set
            {
                _selectedFacility = value;
                OnPropertyChanged();
            }
        }

        #region Commands
        public ICommand AssignCommand { get; private set; }
        public ICommand CloseCommand { get; private set; }
        #endregion

        public AssignRoomFacilityVM(AdminMainVM adminViewModel)
        {
            AdminMainVM = adminViewModel;
            RoomTypes = AdminMainVM.RoomTypes;
            Facilities = AdminMainVM.Facilities;

            AssignCommand = new AssignRoomFacilityCommand(this);
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

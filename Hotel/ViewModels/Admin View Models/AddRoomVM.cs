using Hotel.Commands.Admin_Commands.Room_Commands;
using Hotel.Commands.Navigation_Commands;
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
    public class AddRoomVM : BaseViewModel, Utils.Utility.ICloseWindows
    {
        public ObservableCollection<RoomTypeVM> RoomTypes { get; set; }

        #region Properties
        
        private string _roomNumber;
        public string RoomNumber
        {
            get { return _roomNumber; }
            set
            {
                _roomNumber = value;
                OnPropertyChanged();
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
        #endregion
        
        #region Commands
        public ICommand AddRoomCommand { get; private set; }
        public ICommand CloseCommand { get; private set; }
        #endregion

        public AddRoomVM(AdminMainVM adminViewModel)
        {
            RoomTypes = adminViewModel.RoomTypes;

            AddRoomCommand = new AddRoomCommand(this);
            CloseCommand = new CloseCommand(this);
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


using Hotel.Models.DataAccessLayer;
using Hotel.Models.EntityLayer;
using Hotel.ViewModels.Commands.Admin_Commands;
using Hotel.ViewModels.Commands.Admin_Commands.Room_Commands;
using Hotel.ViewModels.Commands.Navigation_Commands;
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
    public class AdminMainVM : BaseViewModel
    {
        public ObservableCollection<RoomTypeVM> RoomTypes { get; set; }
        private RoomTypeVM _selectedRoomType;
        public RoomTypeVM SelectedRoomType
        {
            get { return _selectedRoomType; }
            set { _selectedRoomType = value; OnPropertyChanged(); }
        }

        #region Commands
        public ICommand OpenAddRoomTypeWindowCommand { get; set; }
        public ICommand OpenEditRoomTypeWindowCommand { get; set; }
        public ICommand DeleteRoomTypeCommand { get; set; }

        public ICommand OpenAddRoomWindowCommand { get; set; }

        #endregion

        public AdminMainVM()
        {
            OpenAddRoomTypeWindowCommand = new OpenAddRoomTypeWindowCommand(this);
            OpenEditRoomTypeWindowCommand = new OpenEditRoomTypeWindowCommand(this);
            DeleteRoomTypeCommand = new DeleteRoomTypeCommand(this);

            OpenAddRoomWindowCommand = new OpenAddRoomWindowCommand(this);

            //read the room types, create wrapers and populate the list
            RoomTypes = new ObservableCollection<RoomTypeVM>();
            foreach (var roomType in RoomTypeDAL.GetRoomTypes())
                RoomTypes.Add(new RoomTypeVM(roomType));
        }
    }
}

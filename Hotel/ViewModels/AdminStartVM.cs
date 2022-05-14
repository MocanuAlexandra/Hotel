using Hotel.Models.DataAccessLayer;
using Hotel.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Hotel.ViewModels
{
    public class AdminStartVM : BaseViewModel
    {
        public ObservableCollection<RoomType> RoomTypes { get; set; }

        #region DataMembers
        private RoomType _selectedRoomType;
        public RoomType SelectedRoomType
        {
            get { return _selectedRoomType; }
            set
            {
                _selectedRoomType = value;
                OnPropertyChanged("SelectedRoomType");
            }
        }
        #endregion

        #region Commands
        public ICommand OpenAddRoomTypeWindowCommand { get; set; }
        #endregion

        public AdminStartVM()
        {
            OpenAddRoomTypeWindowCommand = new Commands.OpenAddRoomTypeWindowCommand(this);         
            RoomTypes = RoomTypeDAL.GetRoomTypes();
        }
        
        // add a new room type into osbervable collection
        public void AddRoomType(string name, string capacity)
        {
            RoomTypes.Add(new RoomType(name, capacity));
            SelectedRoomType = RoomTypes.Last();
        }
    }
}

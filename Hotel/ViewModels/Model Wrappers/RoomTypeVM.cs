using Hotel.Models.EntityLayer;
using Hotel.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.ViewModels.Model_Wrappers
{
    //wrapper class for RoomType model that will be used in the view model as a representative
    public class RoomTypeVM : BaseViewModel
    {
        public readonly RoomType _roomType;

        public int Id
        {
            get { return _roomType.Id; }
            set { _roomType.Id = value; OnPropertyChanged(); }
        }
        public string Name
        {
            get { return _roomType.Name; }
            set { _roomType.Name = value; OnPropertyChanged(); }
        }
        public int Capacity
        {
            get { return _roomType.Capacity; }
            set { _roomType.Capacity = value; OnPropertyChanged(); }
        }
        public ObservableCollection<Room> RoomsOfType
        {
            get { return _roomType.RoomsOfType; }
            set { _roomType.RoomsOfType = value; OnPropertyChanged(); }
        }
        public ObservableCollection<Facility> Facilities
        {
            get { return _roomType.Facilities; }
            set { _roomType.Facilities = value; OnPropertyChanged(); }
        }
        public bool IsActive
        {
            get { return _roomType.IsActive; }
            set { _roomType.IsActive = value; OnPropertyChanged(); }
        }

        public RoomTypeVM(RoomType roomType)
        {
            _roomType = roomType;
        }
    }
}

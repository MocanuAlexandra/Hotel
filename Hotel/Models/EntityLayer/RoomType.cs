using Hotel.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Models.EntityLayer
{
    public class RoomType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int NumberOfRooms => RoomsOfType.Count;
        public ObservableCollection<Room> RoomsOfType { get; set; }
        public bool IsActive { get; set; }
    }
}

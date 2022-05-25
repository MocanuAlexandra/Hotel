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
        public ObservableCollection<Room> RoomsOfType { get; set; }
        public ObservableCollection<Facility> Facilities { get; set; }
        public ObservableCollection<Price> Prices { get; set; }
        public ObservableCollection< ImageRoom> Images { get; set; }
        public bool IsActive { get; set; }
    }
}

﻿using Hotel.Utils;
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
       public RoomType()
        {
            this.Facilities = new ObservableCollection<Facility>();
        }
        
        public int Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public ObservableCollection<Room> RoomsOfType { get; set; }
        public virtual ObservableCollection<Facility> Facilities { get; set; }
        public bool IsActive { get; set; }
    }
}

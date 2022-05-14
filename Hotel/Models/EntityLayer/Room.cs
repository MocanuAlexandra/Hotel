﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Models.EntityLayer
{
    public class Room
    {
        // constructor
        public Room()
        {
            this.Facilities = new HashSet<Facility>();
            this.Bookings = new HashSet<Booking>();
        }

        //define primary key
        [Key]
        public int RoomId { get; set; }

        //define other attributes      

        // define collection for many to many relationship
        public virtual ICollection<Facility> Facilities { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }

        public bool IsActive { get; set; }

    }
}

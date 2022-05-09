using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Models.EntityLayer
{
    public class Facility
    {
        // constructor 
        public Facility()
        {
            this.Rooms = new HashSet<Room>();
        }

        // define primary key
        [Key]
        public int FacilityId { get; set; }

        // define other attributes
        [Required(ErrorMessage = "Please enter a facility name")]
        public string FacilityName { get; set; }

        // define collection for many-to-many relationship
        public virtual ICollection<Room> Rooms { get; set; }

        public bool IsActive { get; set; }
    }
}

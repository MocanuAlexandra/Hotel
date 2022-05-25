using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Models.EntityLayer
{
    public class Facility
    {      
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

        // define collection for many-to-namy relation with roomType
        public ObservableCollection<RoomType> RoomTypes { get; set; }
    }
}

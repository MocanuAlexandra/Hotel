using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Models.EntityLayer
{
    public class Price
    {
        // constructor
        //public Price()
        //{
        //    this.RoomTypes = new HashSet<RoomType>();
        //}
        
        [Key]
        public int PriceId { get; set; }
        public double PriceValue { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        // define relationship 1 to many with RoomType
       // public ICollection<RoomType> RoomTypes { get; set; }
    }
}

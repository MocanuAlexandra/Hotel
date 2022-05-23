using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Utils
{
    public interface IBookingItem
    {
        string ItemName { get; }
        uint ItemQuantity { get; set; }
        float TotalPriceForPeriod { get; set; }
    }
}

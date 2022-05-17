using Hotel.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.ViewModels.Model_Wrappers
{
    //wrapper class for Hotel services model that will be used in the view model as a representative
    public class HotelServicesVM : BaseViewModel
    {
        public readonly HotelService _hotelService;

        public int Id
        {
            get { return _hotelService.Id; }
            set { _hotelService.Id = value; OnPropertyChanged(); }
        }
        public string Name
        {
            get { return _hotelService.Name; }
            set { _hotelService.Name = value; OnPropertyChanged(); }
        }
        public bool IsActive
        {
            get { return _hotelService.IsActive; }
            set { _hotelService.IsActive = value; OnPropertyChanged(); }
        }

        public HotelServicesVM(HotelService hotelService)
        {
            _hotelService = hotelService;
        }
    }
}


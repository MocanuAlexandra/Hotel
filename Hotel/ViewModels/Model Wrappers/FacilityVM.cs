using Hotel.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.ViewModels.Model_Wrappers
{
    public class FacilityVM:BaseViewModel
    {
        public readonly Facility _facility;

        public int Id
        {
            get { return _facility.Id; }
            set { _facility.Id = value; OnPropertyChanged(); }
        }
        public string Name
        {
            get { return _facility.Name; }
            set { _facility.Name = value; OnPropertyChanged(); }
        }
        public bool IsActive
        {
            get { return _facility.IsActive; }
            set { _facility.IsActive = value; OnPropertyChanged(); }
        }
        
       public ObservableCollection<RoomType> RoomTypes
        {
            get { return _facility.RoomTypes; }
            set { _facility.RoomTypes = value; OnPropertyChanged(); }
        }

        public FacilityVM(Facility facility)
        {
            _facility = facility;
        }
    }
}
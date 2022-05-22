using Hotel.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.ViewModels.Model_Wrappers
{
    //wrapper class for Price model that will be used in the view model as a representative
    public class PriceVM : BaseViewModel
    {
        public readonly Price _price;

        public int Id
        {
            get { return _price.Id; }
        }
        public float Value
        {
            get { return _price.Value; }
            set { _price.Value = value; OnPropertyChanged(); }
        }
        public string Description
        {
            get { return _price.Description; }
            set { _price.Description = value; OnPropertyChanged(); }
        }
        public DateTime ValabilityStartDate
        {
            get { return _price.ValabilityStartDate; }
            set { _price.ValabilityStartDate = value; OnPropertyChanged(); }
        }
        public DateTime ValabilityEndDate
        {
            get { return _price.ValabilityEndDate; }
            set { _price.ValabilityEndDate = value; OnPropertyChanged(); }
        }
        public int AssignedRoomTypeId
        {
            get { return _price.AssignedRoomTypeId; }
            set { _price.AssignedRoomTypeId = value; OnPropertyChanged(); }
        }
        public RoomType AssignedRoomType
        {
            get { return _price.AssignedRoomType; }
            set { _price.AssignedRoomType = value; OnPropertyChanged(); }
        }

        public bool IsActive
        {
            get { return _price.IsActive; }
            set { _price.IsActive = value; OnPropertyChanged(); }
        }

        public PriceVM(Price price)
        {
            _price = price;
        }
    }
}

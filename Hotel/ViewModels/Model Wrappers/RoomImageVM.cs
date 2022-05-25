using Hotel.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.ViewModels.Model_Wrappers
{
    public class RoomImageVM:BaseViewModel
    {
        public readonly ImageRoom _roomImage;

        public int Id
        {
            get { return _roomImage.Id; }
            set
            {
                _roomImage.Id = value;
                OnPropertyChanged("Id");
            }
        }

        public byte[] ImageData
        {
            get { return _roomImage.ImageData; }
            set
            {
                _roomImage.ImageData = value;
                OnPropertyChanged("ImageData");
            }
        }

        public bool IsActive
        {
            get { return _roomImage.IsActive; }
            set
            {
                _roomImage.IsActive = value;
                OnPropertyChanged("IsActive");
            }
        }
        public int RoomTypeId
        {
            get { return _roomImage.RoomTypeId; }
            set
            {
                _roomImage.RoomTypeId = value;
                OnPropertyChanged("RoomTypeId");
            }
        }
        public RoomType RoomType
        {
            get { return _roomImage.RoomType; }
            set
            {
                _roomImage.RoomType = value;
                OnPropertyChanged("RoomType");
            }
        }
        public RoomImageVM(ImageRoom roomImage)
        {
            _roomImage = roomImage;
        }
    }
}

using Hotel.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.ViewModels.Model_Wrappers
{
    //wrapper class for Image model that will be used in the view model as a representative
    public class ImageVM:BaseViewModel
    {
        private readonly RoomImage _image;

        public int Id
        {
            get { return _image.Id; }
            set
            {
                _image.Id = value;
                OnPropertyChanged("Id");
            }
        }

        public string Name
        {
            get { return _image.Name; }
            set
            {
                _image.Name = value;
                OnPropertyChanged("Name");
            }
        }

        public byte[] Content
        {
            get { return _image.Content; }
            set
            {
                _image.Content = value;
                OnPropertyChanged("Content");
            }
        }

        public RoomType RoomType
        {
            get { return _image.RoomType; }
            set
            {
                _image.RoomType = value;
                OnPropertyChanged("RoomType");
            }
        }
        public int RoomTypeId
        {
            get { return _image.RoomTypeId; }
            set
            {
                _image.RoomTypeId = value;
                OnPropertyChanged("RoomTypeId");
            }
        }

        public bool IsActive
        {
            get { return _image.IsActive; }
            set
            {
                _image.IsActive = value;
                OnPropertyChanged("RoomTypeId");
            }
        }

        public ImageVM(RoomImage image)
        {
            _image = image;
        }
    }
}

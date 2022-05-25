using Hotel.Models.DataAccessLayer;
using Hotel.Models.EntityLayer;
using Hotel.Utils;
using Hotel.ViewModels;
using Hotel.ViewModels.Model_Wrappers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Hotel.Commands.Admin_Commands.Images_Commands
{
    public class AddImageCommand:BaseCommand
    {
        private readonly RoomImageEditVM _roomImageEditVM;

        public AddImageCommand(RoomImageEditVM roomImageEditVM)
        {
            _roomImageEditVM = roomImageEditVM;
            _roomImageEditVM.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override void Execute(object parameter)
        {
            ImageRoom imageRoom = new ImageRoom()
            {
                ImageData = Utility.ConvertBitmapImageToByteArray(_roomImageEditVM.ImageForRoomType),
                RoomType = _roomImageEditVM.SelectedRoomType._roomType,
                IsActive = true,
            };

            
            // add image to database and to the list 
            ImageRoomDAL.AddImage(imageRoom, _roomImageEditVM.SelectedRoomType._roomType);
            _roomImageEditVM.AdminMainVM.Images.Add(new RoomImageVM(imageRoom));

            MessageBox.Show("Image added successfully!", "Success", MessageBoxButton.OK,
               MessageBoxImage.Information);

            _roomImageEditVM.CloseWindow();
        }

        public override bool CanExecute(object parameter)
        {
            return _roomImageEditVM.SelectedRoomType != null &&
                (_roomImageEditVM.ImagePath) != null &&
                base.CanExecute(parameter);
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(RoomImageEditVM.SelectedRoomType)
                || e.PropertyName == nameof(RoomImageEditVM.ImagePath))
            {
                OnCanExecuteChanged();
            }
        }
    }
}
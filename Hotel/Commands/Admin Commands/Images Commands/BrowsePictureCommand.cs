using Hotel.ViewModels;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Hotel.Commands.Admin_Commands.Images_Commands
{
    public class BrowsePictureCommand : BaseCommand
    {
        private readonly RoomImageEditVM _roomImageditVM;

        public BrowsePictureCommand(RoomImageEditVM roomImageditVM)
        {
            _roomImageditVM = roomImageditVM;
        }

        public override void Execute(object parameter)
        {
            //open a file dialog with filter for images only of all types
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | " +
                "*.jpg; *.jpeg; *.jpe; *.jfif; *.png",

                InitialDirectory = @"D:\Facultate\anul II\sem 2\MVP\tema 3\Hotel_git\Hotel\Images\RoomImages",
            };

            if (openFileDialog.ShowDialog() == true)
            {
                _roomImageditVM.ImagePath = openFileDialog.FileName;
                _roomImageditVM.ImageForRoomType = new BitmapImage(new Uri(_roomImageditVM.ImagePath));
            }
        }
    }
}

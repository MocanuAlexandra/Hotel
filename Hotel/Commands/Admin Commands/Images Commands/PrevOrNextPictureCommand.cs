using Hotel.Utils;
using Hotel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Commands.Admin_Commands.Images_Commands
{
    public class PrevOrNextPictureCommand : BaseCommand
    {
        private readonly RoomImageEditVM _imageViewModel;
        public PrevOrNextPictureCommand(RoomImageEditVM imageViewModel)
        {
            _imageViewModel = imageViewModel;
        }

        //the paramater is going to be a string that takes the value "-1" if we want to go to
        //the previous picture or "1" if we want to go to the next picture
        public override void Execute(object parameter)
        {
            int prevOrNextFlag = int.Parse(parameter.ToString());

            //getting the index of the current picture in the list of pictures
            string selectedProfilePictureName = Utility.PicureNameFromPath(_imageViewModel.ImageForRoomType);
            int selectedProfilePictureIndex = _imageViewModel.Images.IndexOf(selectedProfilePictureName);

            if (selectedProfilePictureIndex == -1)
                return;

            selectedProfilePictureIndex += prevOrNextFlag;
            if (selectedProfilePictureIndex >= _imageViewModel.Images.Count)
                selectedProfilePictureIndex = 0;
            else if (selectedProfilePictureIndex < 0)
                selectedProfilePictureIndex = _imageViewModel.Images.Count - 1;

            _imageViewModel.ImageForRoomType =
                Utility.PictureNameToPath(_imageViewModel.Images[selectedProfilePictureIndex]);
        }
    }
}

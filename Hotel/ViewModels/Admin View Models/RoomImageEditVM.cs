using Hotel.Commands.Admin_Commands.Images_Commands;
using Hotel.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Hotel.ViewModels
{
    public class RoomImageEditVM:BaseViewModel, Utils.Utility.ICloseWindows
    {
        #region Properties
        private string _imageForRoomType;
        public string ImageForRoomType
        {
            get { return _imageForRoomType; }
            set
            {
                _imageForRoomType = value;
                OnPropertyChanged("ImageForRoomType");
            }
        }

        private readonly List<string> _images;
        public List<string> Images
        {
            get { return _images; }
        }

        public AdminMainVM AdminMainVM { get; private set; }
        #endregion

        #region Commands
        public ICommand NextPictureCommand { get; }
        public ICommand PrevPictureCommand { get; }
        public ICommand AddImageCommand { get; }
        public ICommand CloseCommand { get; }
        #endregion

        public RoomImageEditVM(AdminMainVM adminViewModel)
        {
            AdminMainVM = adminViewModel;
            _images = Utility.LoadPicturesPaths();

            ImageForRoomType = Utility.PictureNameToPath(Constants.defaultPictureName);

            // AddImageCommand = new AddImageCommand(this);
            PrevPictureCommand = new PrevOrNextPictureCommand(this);
            NextPictureCommand = new PrevOrNextPictureCommand(this);           
        }
        #region Methods
        public Action Close { get; set; }
        public void CloseWindow()
        {
            //if the close action has subscribers, it calls them, closing the 
            //windows that use this viewModel (see MainWindow code-behind)
            Close?.Invoke();
        }
        #endregion
    }
}

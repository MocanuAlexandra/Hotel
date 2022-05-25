using Hotel.Commands.Admin_Commands.Images_Commands;
using Hotel.Commands.Navigation_Commands;
using Hotel.Utils;
using Hotel.ViewModels.Model_Wrappers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Hotel.ViewModels
{
    public class RoomImageEditVM:BaseViewModel, Utils.Utility.ICloseWindows
    {
        #region Properties

        private string _imagePath;
        public string ImagePath
        {
            get { return _imagePath; }
            set
            {
                _imagePath = value;
                OnPropertyChanged("ImagePath");
            }
        }
        
        private BitmapImage _imageForRoomType;
        public BitmapImage ImageForRoomType
        {
            get { return _imageForRoomType; }
            set
            {
                _imageForRoomType = value;
                OnPropertyChanged("ImageForRoomType");
            }
        }

        public AdminMainVM AdminMainVM { get; private set; }

        public ObservableCollection<RoomTypeVM> RoomTypes { get; set; }
        
        private RoomTypeVM _selectedRoomType;
        public RoomTypeVM SelectedRoomType
        {
            get { return _selectedRoomType; }
            set
            {
                _selectedRoomType = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Commands
        public ICommand AddImageCommand { get; }
        public ICommand BrowsePictureCommand { get; }
        public ICommand CloseCommand { get; }
        #endregion

        public RoomImageEditVM(AdminMainVM adminViewModel)
        {
            AdminMainVM = adminViewModel;
            RoomTypes = adminViewModel.RoomTypes;

            CloseCommand = new CloseCommand(this);
            BrowsePictureCommand = new BrowsePictureCommand(this);
            AddImageCommand = new AddImageCommand(this);
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

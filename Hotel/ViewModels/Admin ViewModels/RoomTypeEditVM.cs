using Hotel.Commands.Edit_Room_Type_Commands;
using Hotel.Commands.Navigation_Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Hotel.ViewModels
{
    public class RoomTypeEditVM : BaseViewModel, Utils.Utility.ICloseWindows
    {
        public enum RoomTypeEditMode
        {
            Add,
            Edit
        }

        public AdminMainVM AdminMainVM { get; private set; }
        public RoomTypeEditMode Mode { get; set; }

        //displays create if the window is opened in create mode, or edit if it is opened in edit mode
        public string SubmitButtonContent => Mode.ToString();

        #region RoomType Properties
        private string _roomTypeName;
        private string _capacity;

        public string RoomTypeName
        {
            get { return _roomTypeName; }
            set { _roomTypeName = value; OnPropertyChanged(); }
        }
        public string Capacity
        {
            get { return _capacity; }
            set { _capacity = value; OnPropertyChanged(); }
        }
        #endregion

        #region Commands
        public ICommand SubmitRoomTypeCommand { get; private set; }
        public ICommand CloseCommand { get; private set; }
        #endregion

        public RoomTypeEditVM(AdminMainVM adminMainVM, RoomTypeEditMode mode)
        {
            AdminMainVM = adminMainVM;
            Mode = mode;
            SubmitRoomTypeCommand = new SubmitRoomTypeCommand(this);
            CloseCommand = new CloseCommand(this);

            //if we're in the edit mode we need to populate the fields with the room type's data
            if (mode == RoomTypeEditMode.Edit)
            {
                RoomTypeName = AdminMainVM.SelectedRoomType.Name;
                Capacity = AdminMainVM.SelectedRoomType.Capacity.ToString();
            }
        }

        public Action Close { get; set; }
        public void CloseWindow()
        {
            //if the close action has subscribers, it calls them, closing the 
            //windows that use this viewModel 
            Close?.Invoke();
        }
    }
}
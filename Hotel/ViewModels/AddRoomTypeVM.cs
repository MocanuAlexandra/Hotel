using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Hotel.ViewModels
{
    public class AddRoomTypeVM:BaseViewModel, Utils.Utility.ICloseWindows
    {
        private string _inputRoomType;
        private string _inputRoomCapacity;
        private string _errorMessage;

        public AdminStartVM AdminStartVM { get; set; }
        public string InputRoomType
        {
            get { return _inputRoomType; }
            set
            {
                _inputRoomType = value;
                ErrorMessage = "";
                OnPropertyChanged();
            }
        }
        public string InputRoomCapacity
        {
            get { return _inputRoomCapacity; }
            set
            {
                _inputRoomCapacity = value;
                ErrorMessage = "";
                if (!Utils.Utility.IsNumber(value))
                {
                    ErrorMessage = "Capacity must be a number";
                }
                OnPropertyChanged();
            }
        }

        public string ErrorMessage
        {
            get
            {
                return _errorMessage;
            }
            set
            {
                _errorMessage = value;
                OnPropertyChanged("ErrorMessage");
            }
        }


        public ICommand AddRoomTypeCommand { get; set; }
        public AddRoomTypeVM()
        {
            AddRoomTypeCommand = new Commands.AddRoomTypeCommand(this);
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

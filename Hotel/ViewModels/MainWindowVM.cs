using Hotel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Hotel.Commands.Welcome_Page_Commands;
using Hotel.Commands.Navigation_Commands;

namespace Hotel.ViewModels
{
    public class MainWindowVM : BaseViewModel, Utils.Utility.ICloseWindows
    {
        #region Properties

        private BaseViewModel _currentViewModel;
        public int _currentHeight;
        public int _currentWidth;

        public BaseViewModel CurrentViewModel
        {
            get { return _currentViewModel; }
            set
            {
                _currentViewModel = value;
                OnPropertyChanged();
            }
        }

        public int CurrentHeight
        {
            get { return _currentHeight; }
            set
            {
                _currentHeight = value;
                OnPropertyChanged();
            }
        }

        public int CurrentWidth
        {
            get { return _currentWidth; }
            set
            {
                _currentWidth = value;
                OnPropertyChanged();
            }
        }

        public StartVM StartVM { get; set; }

        #endregion

        #region Commands

        // welcome window commands
        public ICommand SignInCommand { get; set; }
        public ICommand LoginCommand { get; set; }
        public ICommand SignUpCommand { get; set; }
        public ICommand RegisterCommand { get; set; }
        public ICommand BackToMainVMCommand { get; set; }

        // navigation commands
        public ICommand LogoutCommand { get; set; }
        public ICommand CloseCommand { get; set; }
        public ICommand GuestViewCommand { get; set; }
        #endregion

        public MainWindowVM()
        {
            StartVM = new StartVM();
            CurrentViewModel = StartVM;

            // welcome window commands
            SignInCommand = new SignInCommand(this);
            LoginCommand = new LoginCommand(this);
            SignUpCommand = new SignUpCommand(this);
            RegisterCommand = new RegisterCommand(this);

            // navigation commands
            LogoutCommand = new LogoutCommand(this);
            CloseCommand = new CloseCommand(this);
            GuestViewCommand = new GuestViewCommand(this);
            BackToMainVMCommand = new BackToMainVMCommand(this);

            CurrentWidth = Utils.Constants.DefaultWindowSize.windowWidth;
            CurrentHeight = Utils.Constants.DefaultWindowSize.windowHeight;
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

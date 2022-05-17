using Hotel.Models.DataAccessLayer;
using Hotel.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Hotel.Commands.Admin_Commands.Room_Commands
{
    public class RemoveRoomCommand:BaseCommand
    {
        private readonly RemoveRoomVM _removeRoomViewModel;
        public RemoveRoomCommand(RemoveRoomVM removeRoomViewModel)
        {
            _removeRoomViewModel = removeRoomViewModel;
            _removeRoomViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override void Execute(object parameter)
        {
            RoomDAL.DeleteRoom(_removeRoomViewModel.SelectedRoomToBeDeleted);

            MessageBox.Show("Room removed successfully!", "Success", MessageBoxButton.OK,
                  MessageBoxImage.Information);
            
            // after we execute the command, we need to close the window
            _removeRoomViewModel.CloseWindow();
        }

        public override bool CanExecute(object parameter)
        {
            return _removeRoomViewModel.SelectedRoomType != null
                && _removeRoomViewModel.SelectedRoomToBeDeleted != null
                && base.CanExecute(parameter);
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(RemoveRoomVM.SelectedRoomType)
                || e.PropertyName == nameof(RemoveRoomVM.SelectedRoomToBeDeleted))
            {
                OnCanExecuteChanged();
            }
        }
    }
}

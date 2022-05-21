using Hotel.Models.DataAccessLayer;
using Hotel.Models.EntityLayer;
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
    public class AddRoomCommand:BaseCommand
    {
        private readonly AddRoomVM _addRoomViewModel;
        public AddRoomCommand(AddRoomVM addRoomViewModel)
        {
            _addRoomViewModel = addRoomViewModel;
            _addRoomViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override void Execute(object parameter)
        {
            //check if the room number is valid and if it is, add the room to the database
            if (int.TryParse(_addRoomViewModel.RoomNumber, out int roomNumber))
            {
                Room room = new Room()
                {
                    Number = roomNumber,
                    IsActive = true,
                    RoomType = _addRoomViewModel.SelectedRoomType._roomType
                };

                RoomDAL.AddRoom(room, _addRoomViewModel.SelectedRoomType._roomType);

                MessageBox.Show("Room added successfully!", "Success", MessageBoxButton.OK,
                    MessageBoxImage.Information);
            }
            else
                MessageBox.Show("Room number is not valid!", "Error", MessageBoxButton.OK,
                    MessageBoxImage.Error);

            // after adding the room, we close the window
            _addRoomViewModel.CloseWindow();
        }

        public override bool CanExecute(object parameter)
        {
            return _addRoomViewModel.SelectedRoomType != null &&
                !string.IsNullOrEmpty(_addRoomViewModel.RoomNumber) &&
                base.CanExecute(parameter);
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(AddRoomVM.SelectedRoomType)
                || e.PropertyName == nameof(AddRoomVM.RoomNumber))
            {
                OnCanExecuteChanged();
            }
        }
    }
}
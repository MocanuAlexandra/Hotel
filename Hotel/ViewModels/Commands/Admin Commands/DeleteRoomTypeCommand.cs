using Hotel.Models.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.ViewModels.Commands.Admin_Commands
{
    public class DeleteRoomTypeCommand : BaseCommand
    {
        private readonly AdminMainVM _adminMainVM;
        public DeleteRoomTypeCommand(AdminMainVM adminMainVM)
        {
            _adminMainVM = adminMainVM;
            _adminMainVM.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override void Execute(object parameter)
        {
            RoomTypeDAL.DeleteRoomType(_adminMainVM.SelectedRoomType._roomType);
            _adminMainVM.RoomTypes.Remove(_adminMainVM.SelectedRoomType);
        }

        public override bool CanExecute(object parameter)
        {
            return _adminMainVM.SelectedRoomType != null && base.CanExecute(parameter);
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(AdminMainVM.SelectedRoomType))
                OnCanExecuteChanged();
        }
    }
}
using Hotel.Views.Admin_Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.ViewModels.Commands.Admin_Commands
{
    public class OpenEditRoomTypeWindowCommand : BaseCommand
    {
        private readonly AdminMainVM _adminMainVM;
        public OpenEditRoomTypeWindowCommand(AdminMainVM adminMainVM)
        {
            _adminMainVM = adminMainVM;
            _adminMainVM.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override void Execute(object parameter)
        {
            RoomTypeEditWindowView roomTypeEditWindowView = new RoomTypeEditWindowView()
            {
                DataContext = new RoomTypeEditVM(_adminMainVM,
                RoomTypeEditVM.RoomTypeEditMode.Edit)
            };
            roomTypeEditWindowView.ShowDialog();
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


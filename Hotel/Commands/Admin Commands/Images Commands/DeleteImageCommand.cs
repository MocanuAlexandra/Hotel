using Hotel.Models.DataAccessLayer;
using Hotel.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Commands.Admin_Commands.Images_Commands
{
    public class DeleteImageCommand:BaseCommand
    {
        private readonly AdminMainVM _adminMainVM;

        public DeleteImageCommand(AdminMainVM adminMainVM)
        {
            _adminMainVM = adminMainVM;
            _adminMainVM.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override void Execute(object parameter)
        {
            ImageRoomDAL.DeleteImage(_adminMainVM.SelectedImage._roomImage);
            _adminMainVM.Images.Remove(_adminMainVM.SelectedImage);
        }

        public override bool CanExecute(object parameter)
        {
            return _adminMainVM.SelectedImage != null && base.CanExecute(parameter);
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(AdminMainVM.SelectedImage))
                OnCanExecuteChanged();
        }
    }
}

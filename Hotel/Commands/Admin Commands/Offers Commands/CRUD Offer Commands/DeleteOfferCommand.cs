using Hotel.Models.DataAccessLayer;
using Hotel.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Commands.Admin_Commands.Offers_Commands.CRUD_Offer_Commands
{
    public class DeleteOfferCommand:BaseCommand
    {
        private readonly AdminMainVM _adminMainVM;
        public DeleteOfferCommand(AdminMainVM adminMainVM)
        {
            _adminMainVM = adminMainVM;
            _adminMainVM.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override void Execute(object parameter)
        {
            OfferDAL.DeleteOffer(_adminMainVM.SelectedOffer._offer);
            _adminMainVM.Offers.Remove(_adminMainVM.SelectedOffer);
        }

        public override bool CanExecute(object parameter)
        {
            return _adminMainVM.SelectedOffer != null && base.CanExecute(parameter);
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(AdminMainVM.SelectedOffer))
                OnCanExecuteChanged();
        }
    }
}

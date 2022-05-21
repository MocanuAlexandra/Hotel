using Hotel.ViewModels;
using Hotel.Views.Admin_Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Commands.Admin_Commands.Offers_Commands
{
    public class OpenEditOfferWindowCommand:BaseCommand
    {
        private readonly AdminMainVM _adminMainVM;
        public OpenEditOfferWindowCommand(AdminMainVM adminMainVM)
        {
            _adminMainVM = adminMainVM;
            _adminMainVM.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override void Execute(object parameter)
        {
            OfferEditWindow offerEditWindowView = new OfferEditWindow()
            {
                DataContext = new OfferEditVM(_adminMainVM,
                OfferEditVM.OfferEditMode.Edit)
            };
            offerEditWindowView.ShowDialog();
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



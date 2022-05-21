using Hotel.ViewModels;
using Hotel.Views.Admin_Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Commands.Admin_Commands.Offers_Commands
{
    public class OpenAddOfferWindowCommand:BaseCommand
    {
        private readonly AdminMainVM _adminStartVM;
        public OpenAddOfferWindowCommand(AdminMainVM adminStartVM)
        {
            _adminStartVM = adminStartVM;
        }

        public override void Execute(object parameter)
        {
            OfferEditWindow offerEditWindowView = new OfferEditWindow()
            {
                DataContext = new OfferEditVM(_adminStartVM,
                OfferEditVM.OfferEditMode.Add)
            };
            offerEditWindowView.ShowDialog();
        }
    }
}

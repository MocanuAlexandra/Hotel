using Hotel.Models.DataAccessLayer;
using Hotel.Models.EntityLayer;
using Hotel.Utils;
using Hotel.ViewModels;
using Hotel.ViewModels.Model_Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Hotel.Commands.Admin_Commands.Offers_Commands.CRUD_Offer_Commands
{
    public class SubmitOfferCommand : BaseCommand
    {
        private readonly OfferEditVM _offerEditVM;

        public SubmitOfferCommand(OfferEditVM offerEditVM)
        {
            _offerEditVM = offerEditVM;
        }

        private bool ExecuteCreate(float price)
        {
            Offer offer = new Offer();

            //first check if the offer already exists
            if (OfferDAL.GetOfferByName(_offerEditVM.Name) != null)
            {
                MessageBox.Show("Offer already exists", "Error", MessageBoxButton.OK
                     , MessageBoxImage.Error);
                return false;
            }
            else
            {
                offer.Description = _offerEditVM.Name;
                offer.Price = price;
                offer.CheckInDate = _offerEditVM.StartDate;
                offer.CheckOutDate = _offerEditVM.EndDate;
                offer.AssignedRoomType = _offerEditVM.SelectedRoomType._roomType;
                offer.IsActive = true;
            }

            // add offer to database and update offers list
            OfferDAL.AddOffer(offer,_offerEditVM.SelectedRoomType._roomType);
            _offerEditVM.AdminMainVM.Offers.Add(new OfferVM(offer));

            MessageBox.Show("Offer added successfully!", "Success", MessageBoxButton.OK,
                MessageBoxImage.Information);
            
            _offerEditVM.Close();

            return true;
        }

        private void ExecuteEdit(float price)
        {
            _offerEditVM.AdminMainVM.SelectedOffer.Description =
                _offerEditVM.Name;
            _offerEditVM.AdminMainVM.SelectedOffer.Price = price;
            _offerEditVM.AdminMainVM.SelectedOffer.CheckInDate =
                _offerEditVM.StartDate;
            _offerEditVM.AdminMainVM.SelectedOffer.CheckOutDate =
                _offerEditVM.EndDate;
            _offerEditVM.AdminMainVM.SelectedOffer.AssignedRoomType =
                _offerEditVM.SelectedRoomType._roomType;

            // update offer in database and update offers list
            OfferDAL.UpdateOffer(_offerEditVM.AdminMainVM.SelectedOffer._offer,
                _offerEditVM.SelectedRoomType._roomType);
        }

        public override void Execute(object parameter)
        {
            // check if new offer name is valid
            if (!Utility.CheckIfOfferNameIsValid(_offerEditVM.Name))
            {
                MessageBox.Show("Offer description is invalid", "Error", MessageBoxButton.OK
                                   , MessageBoxImage.Error);
                return;
            }

            //check if the new offer price is valid
            if (!float.TryParse(_offerEditVM.Price, out float price) || price < 1)
            {
                MessageBox.Show("Offer price is invalid", "Error", MessageBoxButton.OK
                    , MessageBoxImage.Error);
                return;
            }

            //check if the window is open in create or edit mode and execute accordingly
            if (_offerEditVM.Mode == OfferEditVM.OfferEditMode.Add)
            {
                if (ExecuteCreate(price))
                    //close the window
                    _offerEditVM.CloseWindow();
            }
            else
            {
                ExecuteEdit(price);
                _offerEditVM.CloseWindow();
            }
        }
    }
}

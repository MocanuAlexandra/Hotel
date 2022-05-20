using Hotel.Models.DataAccessLayer;
using Hotel.Models.EntityLayer;
using Hotel.Utils;
using Hotel.ViewModels.Admin_ViewModels;
using Hotel.ViewModels.Model_Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Hotel.Commands.Admin_Commands.Hotel_services_Commands
{
    public class SubmitHotelServiceCommand : BaseCommand
    {
        private readonly HotelServiceEditVM _hotelServiceEditViewModel;

        public SubmitHotelServiceCommand(HotelServiceEditVM hotelServiceEditViewModel)
        {
            _hotelServiceEditViewModel = hotelServiceEditViewModel;
        }

        //is executed if the edit window is open in create mode
        private bool ExecuteCreate(float price)
        {
            HotelService newHotelService = new HotelService();

            // first we have to make sure the room type is not already in the database
            if (!HotelServiceDAL.HotelServiceExists(_hotelServiceEditViewModel.HotelServiceName))
            {
                newHotelService.Name = _hotelServiceEditViewModel.HotelServiceName;
                newHotelService.Price = price;
                newHotelService.IsActive = true;

                //add to the list and database
                HotelServiceDAL.AddHotelService(newHotelService);
                _hotelServiceEditViewModel.AdminMainVM.HotelServices.Add(new HotelServicesVM(newHotelService));

                return true;
            }
            else
            {
                MessageBox.Show("Hotel service already exists", "Error", MessageBoxButton.OK
                    , MessageBoxImage.Error);
                return false;
            }
        }

        //is executed if the edit window is open in edit mode
        private void ExecuteEdit(float price)
        {
            _hotelServiceEditViewModel.AdminMainVM.SelectedHotelService.Name =
                _hotelServiceEditViewModel.HotelServiceName;
            _hotelServiceEditViewModel.AdminMainVM.SelectedHotelService.Price =
                price;

            HotelServiceDAL.UpdateHotelService(_hotelServiceEditViewModel.AdminMainVM.
                SelectedHotelService._hotelService);
        }

        public override void Execute(object parameter)
        {
            //check if the new hotel service data is valid and if they are, create the hotel service
            if (!Utility.CheckIfHotelServiceIsValid(_hotelServiceEditViewModel.HotelServiceName))
            {
                MessageBox.Show("Hotel service name is invalid", "Error", MessageBoxButton.OK
                    , MessageBoxImage.Error);
                return;
            }
            
            //check if the new hotel service price is valid and if it is, create the hotel service
            if (!float.TryParse(_hotelServiceEditViewModel.Price, out float price) || price < 1)
            {
                MessageBox.Show("Hotel service price is invalid", "Error", MessageBoxButton.OK
                    , MessageBoxImage.Error);
                return;
            }

            //check if the window is open in create or edit mode and execute accordingly
            if (_hotelServiceEditViewModel.Mode == HotelServiceEditVM.HotelServiceEditMode.Add)
            {
                if (ExecuteCreate(price))
                    //close the window
                    _hotelServiceEditViewModel.CloseWindow();
            }
            else
            {
                ExecuteEdit(price);
                _hotelServiceEditViewModel.CloseWindow();
            }
        }
    }
}


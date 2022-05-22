using Hotel.Models.EntityLayer;
using Hotel.Utils;
using Hotel.ViewModels;
using Hotel.ViewModels.Model_Wrappers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Hotel.Commands.Admin_Commands.Room_Type_Commands.Price_Edit_Commands
{
    public class SubmitPriceCommand:BaseCommand
    {
        private readonly PriceEditVM _priceEditViewModel;
        public SubmitPriceCommand(PriceEditVM priceEditViewModel)
        {
            _priceEditViewModel = priceEditViewModel;
            _priceEditViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        //checks if the price that the user intends to edit or add does not have
        //overlaping dates with any other price, if it does, it will return the name
        //of the first price that it overlaps with, otherwise it returns null
        private string CheckValidityDatesOverlap(DateTime newStartDate, DateTime newEndDate,
            PriceVM ignorePrice = null)
        {
            //iterate trought the price list asigned to the current room type and check for overlaps
            //ignore the first one, that being the dummy price
            foreach (PriceVM price in _priceEditViewModel.Prices.Skip(1))
            {
                if (price == ignorePrice)
                    continue;

                if (newStartDate <= price.ValabilityStartDate
                    && price.ValabilityStartDate <= newEndDate)
                {
                    return price.Description;
                }

                if (price.ValabilityStartDate <= newStartDate
                    && newStartDate <= price.ValabilityEndDate)
                {
                    return price.Description;
                }
            }

            return null;
        }

        public override void Execute(object parameter)
        {
            // we check the price value and if it is valid, we add the new price to the list (create a new dummy price)
            if (!float.TryParse(_priceEditViewModel.PriceValue, out float priceValue) || priceValue <= 0)
            {
                MessageBox.Show("Price value is not valid", "Error", MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return;
            }
            if (_priceEditViewModel.ValabilityEndDate < _priceEditViewModel.ValabilityStartDate)
            {
                MessageBox.Show("Valability end date must be after valability start date", "Error", MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return;
            }
            
            //price description needs to meet the same criteria as the room type name
            if (!Utility.CheckIfRoomTypeNameIsValid(_priceEditViewModel.Description))
            {
                MessageBox.Show("Price description is not valid", "Error", MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return;
            }

            //the command is binded to both add and edit buttons, the parameter tells us which one it is
            if (parameter is bool createFlag && createFlag == true)
            {
                //check for overlaps with already existing prices
                if (CheckValidityDatesOverlap(_priceEditViewModel.ValabilityStartDate,
                _priceEditViewModel.ValabilityEndDate) is string overlapingWith)
                {
                    MessageBox.Show($"The price time span overlaps with that of the \"{overlapingWith}\" price!",
                        "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                _priceEditViewModel.Prices.Add(new PriceVM(new Price())
                {
                    Value = priceValue,
                    Description = _priceEditViewModel.Description,
                    ValabilityStartDate = _priceEditViewModel.ValabilityStartDate,
                    ValabilityEndDate = _priceEditViewModel.ValabilityEndDate,
                    IsActive = true
                });
                _priceEditViewModel.PriceValue = _priceEditViewModel.Description = string.Empty;
                _priceEditViewModel.ValabilityStartDate = DateTime.Today;
                _priceEditViewModel.ValabilityEndDate = DateTime.Today.AddDays(1);
            }
            else
            {
                //check for overlaps with other prices, give the price that is being edited
                //in order to ignore checking against itself
                if (CheckValidityDatesOverlap(_priceEditViewModel.ValabilityStartDate,
                _priceEditViewModel.ValabilityEndDate, _priceEditViewModel.SelectedPrice) is string overlapingWith)
                {
                    MessageBox.Show($"The price time span overlaps with that of the \"{overlapingWith}\" price!",
                        "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                _priceEditViewModel.SelectedPrice.Value = priceValue;
                _priceEditViewModel.SelectedPrice.Description = _priceEditViewModel.Description;
                _priceEditViewModel.SelectedPrice.ValabilityStartDate = _priceEditViewModel.ValabilityStartDate;
                _priceEditViewModel.SelectedPrice.ValabilityEndDate = _priceEditViewModel.ValabilityEndDate;
            }
        }

        public override bool CanExecute(object parameter)
        {
            //the add button needs to be disabled unless the "New" option is selected
            //and the edit button needs to be disabled if the "New" option is selected

            //the "new" option is always on position 0 in the list
            if (parameter is bool createFlag && createFlag == true)
                return _priceEditViewModel.SelectedPrice == _priceEditViewModel.Prices[0]
                    && base.CanExecute(parameter);
            else
                return _priceEditViewModel.SelectedPrice != _priceEditViewModel.Prices[0]
                    && base.CanExecute(parameter);
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(PriceEditVM.SelectedPrice))
                OnCanExecuteChanged();
        }
    }
}

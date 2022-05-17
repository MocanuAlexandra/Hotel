﻿using Hotel.Commands.Admin_Commands;
using Hotel.Commands.Admin_Commands.Hotel_services_Commands;
using Hotel.Commands.Admin_Commands.Room_Commands;
using Hotel.Models.DataAccessLayer;
using Hotel.Models.EntityLayer;
using Hotel.ViewModels.Model_Wrappers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Hotel.ViewModels
{
    public class AdminMainVM : BaseViewModel
    {
        public ObservableCollection<RoomTypeVM> RoomTypes { get; set; }
        private RoomTypeVM _selectedRoomType;
        public RoomTypeVM SelectedRoomType
        {
            get { return _selectedRoomType; }
            set { _selectedRoomType = value; OnPropertyChanged(); }
        }

        public ObservableCollection<HotelServicesVM> HotelServices { get; set; }
        private HotelServicesVM _selectedHotelService;
        public HotelServicesVM SelectedHotelService
        {
            get { return _selectedHotelService; }
            set { _selectedHotelService = value; OnPropertyChanged(); }
        }

        #region Commands

        // room type commands
        public ICommand OpenAddRoomTypeWindowCommand { get; set; }
        public ICommand OpenEditRoomTypeWindowCommand { get; set; }
        public ICommand DeleteRoomTypeCommand { get; set; }

        // room commands
        public ICommand OpenAddRoomWindowCommand { get; set; }
        public ICommand OpenRemoveRoomWindowCommand { get; set; }

        // hotel service commands
        public ICommand OpenEditServiceWindowCommand { get; set; }
        public ICommand OpenAddServiceWindowCommand { get; set; }
        public ICommand DeleteHotelServiceCommand { get; set; }

        #endregion

        public AdminMainVM()
        {
            OpenAddRoomTypeWindowCommand = new OpenAddRoomTypeWindowCommand(this);
            OpenEditRoomTypeWindowCommand = new OpenEditRoomTypeWindowCommand(this);
            DeleteRoomTypeCommand = new DeleteRoomTypeCommand(this);

            OpenAddRoomWindowCommand = new OpenAddRoomWindowCommand(this);
            OpenRemoveRoomWindowCommand = new OpenRemoveRoomWindowCommand(this);

            OpenEditServiceWindowCommand = new OpenEditServiceWindowCommand(this);
            OpenAddServiceWindowCommand = new OpenAddServiceWindowCommand(this);
            DeleteHotelServiceCommand = new DeleteHotelServiceCommand(this);

            //read the room types, create wrapers and populate the list
            RoomTypes = new ObservableCollection<RoomTypeVM>();
            foreach (var roomType in RoomTypeDAL.GetRoomTypes())
                RoomTypes.Add(new RoomTypeVM(roomType));

            // read the hotel services, create wrapers and populate the list
            HotelServices = new ObservableCollection<HotelServicesVM>();
            foreach (var hotelService in HotelServiceDAL.GetHotelServices())
                HotelServices.Add(new HotelServicesVM(hotelService));
        }
    }
}

using Hotel.Models.DataAccesLayer;
using Hotel.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Models.DataAccessLayer
{
    public class RegisterDAL
    {
        public RegisterDAL() { }

        public bool CanRegisterGuest(string firstname, string lastname, string email, string password, string phone)
        {
            using (var hotelDBContext = new HotelDBContext())
            {
                // first we check if guest already exists in database
                var guest = hotelDBContext.Guests.Where(g => g.Email == email).FirstOrDefault();

                if (guest == null)
                {
                    // if not, we create a new guest
                    guest = new Guest
                    {
                        FirstName = firstname,
                        LastName = lastname,
                        Email = email,
                        Password = password,
                        Phone = phone,
                        IsActive = true
                    };
                    
                    // and add it to database
                    hotelDBContext.Guests.Add(guest);
                    hotelDBContext.SaveChanges();
                    return true;
                }

                // if guest exists in database, we return false so that user can't register again
                else
                {
                    return false;
                    throw new Exception();
                }
            }
        }
    }
}

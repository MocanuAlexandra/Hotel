using Hotel.Models.DataAccesLayer;
using Hotel.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Hotel.Models.DataAccesLayer
{
    public class LoginDAL
    {
        public LoginDAL() { }

        private readonly HotelDBContext hotelDBContext = new HotelDBContext();

        public bool LoginAdmin(string email, string password)
        {
            try
            {
                var adminQuery = (from admin in hotelDBContext.Admins
                                 where admin.Email.Equals(email) && admin.Password.Equals(password)
                                 select admin).FirstOrDefault();
                
                // if an admin with these attributes exits, we return true
                if (adminQuery != null)
                {
                    adminQuery.IsActive = true;
                    hotelDBContext.Admins.Attach(adminQuery);
                    hotelDBContext.Entry(adminQuery).Property(x => x.IsActive).IsModified = true;
                    hotelDBContext.SaveChanges();

                    return true;
                }
                
                return false;
            }
            catch
            {
                throw new Exception( );
            }
        }
    }
}

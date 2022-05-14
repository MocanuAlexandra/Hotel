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

        public int IsAdminInDB(string email, string password)
        {
            using (var hotelDBContext = new HotelDBContext())
            {
                try
                {
                    var adminQuery = (from admin in hotelDBContext.Admins
                                      where admin.Email.Equals(email)
                                      select admin).FirstOrDefault();
                    
                    // if an admin with these attributes exists
                    // we check if the password is correct
                    // if it is, we return ID of the admin
                    if (adminQuery != null && Utility.CheckPassword(password, adminQuery.Password))
                    {
                        adminQuery.IsActive = true;
                        hotelDBContext.Admins.Attach(adminQuery);
                        hotelDBContext.Entry(adminQuery).Property(x => x.IsActive).IsModified = true;
                        hotelDBContext.SaveChanges();

                        return adminQuery.AdminId;
                    }
                    return 0;
                }
                catch
                {
                    throw new Exception();
                }
            }
        }

        public int IsEmployeeInDB(string email, string password)
        {
            using (var hotelDBContext = new HotelDBContext())
            {
                try
                {
                    var employeeQuery = (from employee in hotelDBContext.Employees
                                      where employee.Email.Equals(email)
                                      select employee).FirstOrDefault();

                    // if am employee with these attributes exists
                    // we check if the password is correct
                    // if it is, we return ID of the employee
                    if (employeeQuery != null && Utility.CheckPassword(password, employeeQuery.Password))
                    {
                        employeeQuery.IsActive = true;
                        hotelDBContext.Employees.Attach(employeeQuery);
                        hotelDBContext.Entry(employeeQuery).Property(x => x.IsActive).IsModified = true;
                        hotelDBContext.SaveChanges();

                        return employeeQuery.EmployeeId;
                    }
                    return 0;
                }
                catch
                {
                    throw new Exception();
                }
            }
        }

        public int IsGuestInDB(string email, string password)
        {
            using (var hotelDBContext = new HotelDBContext())
            {
                try
                {
                    var guestQuery = (from guest in hotelDBContext.Guests
                                      where guest.Email.Equals(email)
                                      select guest).FirstOrDefault();

                    // if a guest with these attributes exists
                    // we check if the password is correct
                    // if it is, we return ID of the guest
                    if (guestQuery != null && Utility.CheckPassword(password, guestQuery.Password))
                    {
                        guestQuery.IsActive = true;
                        hotelDBContext.Guests.Attach(guestQuery);
                        hotelDBContext.Entry(guestQuery).Property(x => x.IsActive).IsModified = true;
                        hotelDBContext.SaveChanges();

                        return guestQuery.GuestId;
                    }
                    return 0;
                }
                catch
                {
                    throw new Exception();
                }
            }
        }
    }
}

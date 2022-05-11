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
                                      where admin.Email.Equals(email) && admin.Password.Equals(password)
                                      select admin).FirstOrDefault();

                    // if an admin with these attributes exists, we return ID of the admin
                    if (adminQuery != null)
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
                                      where employee.Email.Equals(email) && employee.Password.Equals(password)
                                      select employee).FirstOrDefault();

                    // if an employee with these attributes exists, we return ID of the employee
                    if (employeeQuery != null)
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
                    var guestQuery = (from employee in hotelDBContext.Guests
                                         where employee.Email.Equals(email) && employee.Password.Equals(password)
                                         select employee).FirstOrDefault();

                    // if an employee with these attributes exists, we return ID of the employee
                    if (guestQuery != null)
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

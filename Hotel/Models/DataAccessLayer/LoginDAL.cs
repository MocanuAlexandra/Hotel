using Hotel.DBContext;
using Hotel.Models.DataAccesLayer;
using Hotel.Models.EntityLayer;
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

        // this method is used to check if admin is in databse or not
        public static int IsAdminInDB(string email, string password)
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

        // this method is used to check if employee is in databse or not
        public static int IsEmployeeInDB(string email, string password)
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

        // this method is used to check if client is in databse or not
        public static int IsClientInDB(string email, string password)
        {
            using (var hotelDBContext = new HotelDBContext())
            {
                try
                {
                    var clientQuery = (from client in hotelDBContext.Clients
                                      where client.Email.Equals(email)
                                      select client).FirstOrDefault();
                    
                    // if a guest with these attributes exists
                    // we check if the password is correct
                    // if it is, we return ID of the guest
                    if (clientQuery != null && Utility.CheckPassword(password, clientQuery.Password))
                    {
                        clientQuery.IsActive = true;
                        hotelDBContext.Clients.Attach(clientQuery);
                        hotelDBContext.Entry(clientQuery).Property(x => x.IsActive).IsModified = true;
                        hotelDBContext.SaveChanges();

                        return clientQuery.ClientId;
                    }
                    return 0;
                }
                catch
                {
                    throw new Exception();
                }
            }
        }

        // get client by email and password
        public static Client GetClient(string email, string password)
        {
            using (var hotelDBContext = new HotelDBContext())
            {
                try
                {
                    var clientQuery = (from client in hotelDBContext.Clients
                                       where client.Email.Equals(email)
                                       select client).FirstOrDefault();

                    // if a guest with these attributes exists
                    // we check if the password is correct
                    // if it is, we return ID of the guest
                    if (clientQuery != null && Utility.CheckPassword(password, clientQuery.Password))
                    {
                        return clientQuery;
                    }
                    return null;
                }
                catch
                {
                    throw new Exception();
                }
            }
        }

        // get client id by instance client
        public static int GetClientId(Client client)
        {
            using (var hotelDBContext = new HotelDBContext())
            {
                try
                {
                    var clientQuery = (from c in hotelDBContext.Clients
                                       where c.ClientId == client.ClientId
                                       select c).FirstOrDefault();

                    // if a guest with these attributes exists
                    // we check if the password is correct
                    // if it is, we return ID of the guest
                    if (clientQuery != null)
                    {
                        return clientQuery.ClientId;
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

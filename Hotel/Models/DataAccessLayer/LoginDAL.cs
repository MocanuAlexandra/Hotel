using Hotel.DBContext;
using Hotel.Models.DataAccesLayer;
using Hotel.Models.EntityLayer;
using Hotel.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Hotel.Models.DataAccesLayer
{
    public class LoginDAL
    {
        public LoginDAL() { }

        #region Admin 
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
                        hotelDBContext.Admins.Attach(adminQuery);            
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

        #endregion

        #region Employee
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
                        hotelDBContext.Employees.Attach(employeeQuery);
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

        //gets all employees into observable colllection labmda expression
        public static ObservableCollection<Employee> GetAllEmployees()
        {
            using (var hotelDBContext = new HotelDBContext())
            {
                try
                {
                    var employees = (from employee in hotelDBContext.Employees
                                     where employee.IsActive == true
                                     select employee).ToList();

                    return new ObservableCollection<Employee>(employees);
                }
                catch
                {
                    throw new Exception();
                }
            }
        }

        // deletes a employee
        public static void DeleteEmployee(Employee employee)
        {
            using (var context = new HotelDBContext())
            {
                context.Employees.Attach(employee);
                context.Employees.Remove(employee);
                context.SaveChanges();
            }
        }
        #endregion

        #region Client
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
                        hotelDBContext.Clients.Attach(clientQuery);              
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

        #endregion       
    }
}

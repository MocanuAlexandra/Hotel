using Hotel.DBContext;
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

        public static bool CanRegisterClient(string firstname, string lastname, string email, string password, string phone)
        {
            using (var hotelDBContext = new HotelDBContext())
            {
                // first we check if guest already exists in database
                var client = hotelDBContext.Clients.Where(g => g.Email == email).FirstOrDefault();

                if (client == null)
                {
                    // if not, we create a new client
                    client = new Client
                    {
                        FirstName = firstname,
                        LastName = lastname,
                        Email = email,
                        Password = password,
                        Phone = phone,
                        IsActive = true
                    };
                    
                    // and add it to database
                    hotelDBContext.Clients.Add(client);
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

        //creates a new employee by email and password
        public static bool CanRegisterEmployee(string email, string password)
        {
            using (var hotelDBContext = new HotelDBContext())
            {
                // first we check if guest already exists in database
                var employee = hotelDBContext.Employees.Where(g => g.Email == email).FirstOrDefault();

                if (employee == null)
                {
                    // if not, we create a new employee
                    employee = new Employee
                    {
                        Email = email,
                        Password = password,
                        IsActive = true
                    };

                    // and add it to database
                    hotelDBContext.Employees.Add(employee);
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

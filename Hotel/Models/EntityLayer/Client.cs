using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Models.EntityLayer
{
    public class Client
    {
        // constructor
        public Client()
        {

        }

        //define primary key
        public int ClientId { get; set; }

        //define other attributes
        //these fileds are required so can't be null

        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        
        public bool IsActive { get; set; }
    }
}

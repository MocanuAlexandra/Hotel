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
        [Key]
        public int ClientId { get; set; }

        //define other attributes
        //these fileds are required so can't be null
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Phone { get; set; }
        
        public bool IsActive { get; set; }
    }
}

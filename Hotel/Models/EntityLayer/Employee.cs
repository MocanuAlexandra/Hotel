using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Models.EntityLayer
{
    public class Employee
    {
        // define primary key
        [Key]
        public int EmployeeId { get; set; }

        //define other attributes
        [Required(ErrorMessage = "Plase enter your username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Plase enter your password")]
        public string Password { get; set; }

        public bool IsActive { get; set; }
    }
}

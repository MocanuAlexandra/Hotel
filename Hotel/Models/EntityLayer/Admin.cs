using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Models.EntityLayer
{
    public class Admin
    {
        [Key] //define primary key
        public int AdminId { get; set; }

        //define other attributes
        [Required(ErrorMessage = "Please enter your username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please enter your password")]
        public string Password { get; set; }

        public bool IsActive { get; set; }
    }
}

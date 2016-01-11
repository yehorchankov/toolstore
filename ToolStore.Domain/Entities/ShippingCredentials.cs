using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ToolStore.Domain.Entities
{
    public class ShippingCredentials
    {
        [Required(ErrorMessage = "Please enter your first name")]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your second name")]
        [Display(Name = "Second name")]
        public string SecondName { get; set; }

        //[Required(ErrorMessage = "Please enter a city name")]
        //public string Country { get; set; }

        //[Required(ErrorMessage = "Please enter a state name")]
        //public string State { get; set; }

        [Required(ErrorMessage = "Please enter your address")]
        [EmailAddress(ErrorMessage = "Please be sure to enter correct email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your phone")]
        [Phone(ErrorMessage = "Please be sure to enter correct phone number")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Please enter your address")]
        public string Address { get; set; }
    }
}

#region

using System.ComponentModel.DataAnnotations;

#endregion

namespace ToolStore.Domain.Entities
{
    /// <summary>
    /// Incapsulates data about customer's contacts
    /// </summary>
    public class ShippingDetails
    {
        [Required(ErrorMessage = "Please enter your first name")]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your second name")]
        [Display(Name = "Second name")]
        public string SecondName { get; set; }

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
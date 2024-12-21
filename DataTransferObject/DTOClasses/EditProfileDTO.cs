using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject.DTOClasses
{
    public class EditProfileDTO
    {
        [Required(ErrorMessage = "Entering a name is required.")]
        [Display(Name = "FirstName")]
        public string? FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required.")]
        [Display(Name = "LastName")]
        public string? LastName { get; set; }
        [Required(ErrorMessage = "Entering an email address is required.")]
        [Display(Name = "EmailAddres")]
        [EmailAddress(ErrorMessage = "The entered email address format is invalid.")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Entering a mobile number is required.")]
        [Display(Name = "PhoneNumber")]
        public string? Phone { get; set; }
    }
}

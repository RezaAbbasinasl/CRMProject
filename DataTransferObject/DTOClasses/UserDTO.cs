using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject.DTOClasses;

public class UserDTO : BaseDTO
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
    [Required(ErrorMessage = "Password is required.")]
    [StringLength(100, ErrorMessage = "Password must be at least 6 characters long.", MinimumLength = 6)]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string? Password { get; set; }
    [Required(ErrorMessage = "Entering a repeat password is required.")]
    [DataType(DataType.Password)]
    [Display(Name = "Repeat password")]
    [Compare("Password", ErrorMessage = "The password and its repetition must be the same.")]
    public string? ConfirmPassword { get; set; }
    [Required(ErrorMessage = "Username is required.")]
    [Display(Name = "UserName")]
    [RegularExpression(@"^[a-zA-Z0-9]*$", ErrorMessage = "The username entered is not in the correct format.")]
    public string? UserName { get; set; }        
}

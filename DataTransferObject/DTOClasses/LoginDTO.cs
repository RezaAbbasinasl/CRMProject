using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject.DTOClasses;

public class LoginDTO
{
    [Required(ErrorMessage = "درج آدرس ایمیل اجباری است")]
    [EmailAddress]
    public string? Email { get; set; }

    [Required(ErrorMessage = "درج رمز عبور اجباری است")]
    [DataType(DataType.Password)]
    public string? Password { get; set; }

    [Display(Name = "Remember me?")]
    public bool RememberMe { get; set; }
}

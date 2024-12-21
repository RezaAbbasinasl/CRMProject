using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject.DTOClasses;

public class RoleDTO : BaseDTO
{
    [MaxLength(256, ErrorMessage = "You have entered more than the allowed amount.")]
    [Display(Name = "Name")]
    public string? Name { get; set; }
    public string? RolePersianName { get; set; }
    [MaxLength(256, ErrorMessage = "You have entered more than the allowed amount.")]
    [Display(Name = "Name")]
    public string? RoleDescription { get; set; }

    public void UpdateRole(Guid id)
    {
        this.UpdatedDataTime = DateTime.Now;
        this.UpdatedUserId = id;
    }
}

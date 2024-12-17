using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject.DTOClasses;

public class RoleDTO : BaseDTO
{
    public string? Name { get; set; }
    public string? RolePersianName { get; set; }
    public string? RoleDescription { get; set; }
}

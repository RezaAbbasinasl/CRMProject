using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject.DTOClasses;

public class CategoryDTO : BaseDTO
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public Guid DepartementId { get; set; }
    public List<DepartementDTO> Departements { get; set; } = new List<DepartementDTO>();
}

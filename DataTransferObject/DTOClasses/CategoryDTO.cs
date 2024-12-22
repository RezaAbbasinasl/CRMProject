using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject.DTOClasses;

public class CategoryDTO : BaseDTO
{
    [Required(ErrorMessage = "Entering a name is required.")]
    [MaxLength(200, ErrorMessage = "You have entered more than the allowed amount.")]
    [Display(Name = "Name")]
    public string? Name { get; set; }
    [Required(ErrorMessage = "Entering a Description is required.")]
    [MaxLength(400, ErrorMessage = "You have entered more than the allowed amount.")]
    [Display(Name = "Description")]
    public string? Description { get; set; }
    public Guid DepartementId { get; set; }
    public List<DepartementDTO> Departements { get; set; } = new List<DepartementDTO>();

    public void UpdateCategory(Guid id)
    {
        this.UpdatedDataTime = DateTime.Now;
        this.UpdatedUserId = id;
    }
}

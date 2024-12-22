using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject.DTOClasses;

public class EditCategoryDTO
{
    public Guid Id { get; set; }
    [Required(ErrorMessage = "Entering a name is required.")]
    [Display(Name = "Name")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Entering a Description is required.")]
    [Display(Name = "Description")]
    public string Description { get; set; }
}

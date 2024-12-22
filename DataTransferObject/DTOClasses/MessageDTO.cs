using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject.DTOClasses;

public class MessageDTO : BaseDTO
{
    [Required(ErrorMessage = "The content must not be empty.")]
    [MaxLength(600, ErrorMessage = "You have entered more than the allowed amount.")]
    [Display(Name = "Content")]
    public string? Content { get; set; }
    public Guid TicketId { get; set; }
    public Guid AthureId { get; set; }
}

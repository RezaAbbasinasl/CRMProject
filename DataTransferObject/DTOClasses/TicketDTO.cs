using Shared.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject.DTOClasses;

public class TicketDTO : BaseDTO
{
    [MaxLength(300, ErrorMessage = "You have entered more than the allowed amount.")]
    [Display(Name = "Subject")]
    public string? Subject { get; set; }
    [MaxLength(600, ErrorMessage = "You have entered more than the allowed amount.")]
    [Display(Name = "Description")]
    public string? Description { get; set; }
    public Statuss Status { get; set; } = Statuss.Open;
    public Prioritys Priority { get; set; } = Prioritys.Medium;
    public Scoring Scoring { get; set; } = Scoring.none;
    public string? ScoringDescription { get; set; }
    public Guid AuthorId { get; set; }  
    public Guid CategoryId { get; set; }
    public List<MessageDTO> Messages { get; set; } = new();
    public List<CategoryDTO> Categories { get; set; } = new();
    public UserDTO? AuthorUser { get; set; }
}

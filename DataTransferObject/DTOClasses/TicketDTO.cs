using Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject.DTOClasses;

public class TicketDTO : BaseDTO
{
    public string? Subject { get; set; }
    public string? Description { get; set; }
    public Statuss Status { get; set; }
    public Prioritys Priority { get; set; }
    public Scoring Scoring { get; set; }
    public string? ScoringDescription { get; set; }
    public List<MessageDTO> Messages { get; set; } = new();
    public UserDTO? AuthorUser { get; set; }
}

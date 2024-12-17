using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities;
/// <summary>
/// Message Entity
/// </summary>
public class Message : BaseEntity
{
    /// <summary>
    /// The content of message entity
    /// </summary>
    public string Content { get; set; } = string.Empty;

    /// <summary>
    /// The Athure id of message entity
    /// </summary>
    public Guid AthureId { get; set; }
    /// <summary>
    /// The Athure of message entity
    /// </summary>
    public User? Athure { get; set; }
    /// <summary>
    /// The ticket id of message entity
    /// </summary>
    public Guid TicketId { get; set; }
    /// <summary>
    /// The ticket of message entity
    /// </summary>
    public Ticket? Ticket { get; set; }
}

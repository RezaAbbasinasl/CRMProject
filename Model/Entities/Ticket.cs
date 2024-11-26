using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities;
/// <summary>
/// Ticket Entity
/// </summary>
public class Ticket : BaseEntity<Guid>
{
    /// <summary>
    /// The subject of ticket entity
    /// </summary>
    public string Subject { get; set; } = string.Empty;
    /// <summary>
    /// The description of ticket entity
    /// </summary>
    public string Description { get; set; } = string.Empty;
    /// <summary>
    /// The status id of ticket entity
    /// </summary>
    public int StatusId { get; set; }
    /// <summary>
    /// The priority id of ticket entity
    /// </summary>
    public int PriorityId { get; set; }
    /// <summary>
    /// The scoring id of ticket entity
    /// </summary>
    public int ScoringId { get; set; }
    /// <summary>
    /// The scoring description of ticket entity
    /// </summary>
    public string ScoringDescription { get; set; } = string.Empty;

    /// <summary>
    /// The author id of ticket entity
    /// </summary>
    public Guid AuthorId { get; set; }
    /// <summary>
    /// The author of ticket entity
    /// </summary>
    public User? Author { get; set; }
    /// <summary>
    /// The category id of ticket entity
    /// </summary>
    public Guid CategoryId { get; set; }
    /// <summary>
    /// The category of ticket entity
    /// </summary>
    public Category? Category { get; set; }
    /// <summary>
    /// The list message of ticket entity
    /// </summary>
    public ICollection<Message> Messages { get; set; } = new List<Message>();
}

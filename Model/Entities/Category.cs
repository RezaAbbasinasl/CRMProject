using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities;
/// <summary>
/// Category Entity
/// </summary>
public class Category : BaseEntity
{
    /// <summary>
    /// The category name of category entity
    /// </summary>
    public string Name { get; set; } = string.Empty;
    /// <summary>
    /// The category description of category entity
    /// </summary>
    public string? Description { get; set; } 

    /// <summary>
    /// The list ticket of category entity
    /// </summary>
    public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    /// <summary>
    /// The departement id of category entity
    /// </summary>
    public Guid DepartementId { get; set; }
    /// <summary>
    /// The departement of category entity
    /// </summary>
    public Departement? Departement { get; set; }
}

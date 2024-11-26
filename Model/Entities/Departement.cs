using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities;
/// <summary>
/// Departement Entity
/// </summary>
public class Departement : BaseEntity<Guid>
{
    /// <summary>
    /// The departement name of departement entity 
    /// </summary>
    public string Name { get; set; } = string.Empty;
    /// <summary>
    /// The departement description of departement entity 
    /// </summary>
    public string Description { get; set; } = string.Empty;    

    /// <summary>
    /// The list Users of departement entity
    /// </summary>
    public ICollection<User> Users { get; set; } = new List<User>();
    /// <summary>
    /// The list category of departement entity
    /// </summary>
    public ICollection<Category> Categories { get; set; } = new List<Category>();
}

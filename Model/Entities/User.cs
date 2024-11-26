using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities;
/// <summary>
/// User Entity
/// </summary>
public class User : IdentityUser<Guid>
{
    /// <summary>
    /// The firstName of user entity
    /// </summary>
    public string FirstName { get; set; } = string.Empty;
    /// <summary>
    /// The lastName of user entity
    /// </summary>
    public string LastName { get; set; } = string.Empty;
    /// <summary>
    /// The Active of user entity
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// The created time of user entity
    /// </summary>
    public DateTime CreatedDataTime { get; private set; } = DateTime.Now;
    /// <summary>
    /// The update time of user entity
    /// </summary>
    public DateTime? UpdatedDataTime { get; private set; }
    /// <summary>
    /// The create user id of user entity
    /// </summary>
    public Guid? CreatedUserId { get; set; }
    /// <summary>
    /// The update user id of user entity
    /// </summary>
    public Guid? UpdatedUserId { get; set; }
    /// <summary>
    /// The createdUser of user entity
    /// </summary>
    public User? CreatedUser { get; set; }
    /// <summary>
    /// The updatedUser of user entity
    /// </summary>
    public User? UpdatedUser { get; set; }
    /// <summary>
    /// The Depattement Id of user entity
    /// </summary>
    public Guid? DepartementId { get; set; }
    /// <summary>
    /// The Depattement of user entity
    /// </summary>
    public Departement? Departement { get; set; }
    /// <summary>
    /// The list ticket of user entity
    /// </summary>
    public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    /// <summary>
    /// The list message of user entity
    /// </summary>
    public ICollection<Message> Messages { get; set; } = new List<Message>();
}

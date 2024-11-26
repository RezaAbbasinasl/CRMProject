using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities;
/// <summary>
/// Role Entity
/// </summary>
public class Role : IdentityRole<Guid>
{
    /// <summary>
    /// The persian Name of role entity
    /// </summary>
    public string RolePersianName { get; set; } = string.Empty;
    /// <summary>
    /// The description of role entity
    /// </summary>
    public string RoleDescription { get; set; } = string.Empty;

    /// <summary>
    /// The created time of role entity
    /// </summary>
    public DateTime CreatedDataTime { get; private set; } = DateTime.Now;
    /// <summary>
    /// The update time of role entity
    /// </summary>
    public DateTime? UpdatedDataTime { get; private set; }
    /// <summary>
    /// The create Role id of role entity
    /// </summary>
    public Guid? CreatedUserId { get; set; }
    /// <summary>
    /// The update Role id of role entity
    /// </summary>
    public Guid? UpdatedUserId { get; set; }
    /// <summary>
    /// The createdRole of role entity
    /// </summary>
    public User? CreatedUser { get; set; }
    /// <summary>
    /// The updatedRole of role entity
    /// </summary>
    public User? UpdatedUser { get; set; }
}

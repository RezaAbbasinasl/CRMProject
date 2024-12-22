using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model;

/// <summary>
/// The base entity
/// </summary>
/// <typeparam name="T"></typeparam>
public class BaseEntity
{
    /// <summary>
    /// The type Id field in each table has created in system
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public DateTime? CreatedDataTime { get; private set; } = DateTime.Now;
    /// <summary>
    /// 
    /// </summary>
    public DateTime? UpdatedDataTime { get; private set; }
    /// <summary>
    /// 
    /// </summary>
    public Guid? CreatedUserId { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public Guid? UpdatedUserId { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public User? CreatedUser { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public User? UpdatedUser { get; set; }
}

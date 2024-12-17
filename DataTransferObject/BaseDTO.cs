using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject;

public abstract class BaseDTO
{
    public Guid Id { get; set; }  = Guid.NewGuid();
    public DateTime CreatedDataTime { get; set; } = DateTime.Now;
    public DateTime? UpdatedDataTime { get; set; }
    public Guid? CreateUserId { get; set; } 
}

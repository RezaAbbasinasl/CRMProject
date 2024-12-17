using DataTransferObject.DTOClasses;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ServiceInterfaces;

public interface IRoleService
{
    Task<bool> AddRole(RoleDTO role, Guid userId);
    Task<bool> DeleteRole(Guid roleId, Guid userId);
    Task<bool> UpdateRole(RoleDTO role, Guid userId);
    Task<List<RoleDTO>> AllRole(Guid userId);
    Task<RoleDTO> GetRole(Guid roleId, Guid userId);
}

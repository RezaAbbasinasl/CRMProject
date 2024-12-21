using DataTransferObject.DTOClasses;
using Model.Entities;
using Shared;
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
    Task<List<RoleDTO>> AllRole();
    Task<RoleDTO> GetRole(Guid roleId, Guid userId);
    Task<PaginatedList<RoleDTO>> GetRoleListAsPagination(int pagesize, int pageindex, string searchName);
}


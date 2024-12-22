using DataTransferObject.DTOClasses;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Model.Entities;
using Service.ServiceInterfaces;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ServicClasses;

public class RoleService : IRoleService
{
    private readonly RoleManager<Role> _roleManager;
    private readonly UserManager<User> _userManager;

    public RoleService(RoleManager<Role> roleManager, UserManager<User> userManager)
    {
        _roleManager = roleManager;
        _userManager = userManager;
    }

    public async Task<bool> AddRole(RoleDTO role, Guid userId)
    {
        if (userId == Guid.Empty)
            throw new Exception("");

        var user = _userManager.FindByIdAsync(userId.ToString());

        if (user == null)
            throw new Exception("");

        role.CreateUserId = userId;

        bool isValid = false;
        var resultRole = await _roleManager.CreateAsync(role.Adapt<Role>());

        if(resultRole.Succeeded) 
            isValid = true;

        return isValid;

    }

    public async Task<List<RoleDTO>> AllRole()
    {
        return await _roleManager.Roles.Select(x => x.Adapt<RoleDTO>()).ToListAsync();         
    }

    public async Task<bool> DeleteRole(Guid roleId, Guid userId)
    {
        if (userId == Guid.Empty || roleId == Guid.Empty)
            throw new Exception("");

        var user = await _userManager.FindByIdAsync(userId.ToString());

        if (user == null)
            throw new Exception("");
        var role = await _roleManager.FindByIdAsync(roleId.ToString());
        bool isValid = false;
        if(role != null)
        {
            await _roleManager.DeleteAsync(role);
            isValid = true;
        }

        return isValid;

    }

    public async Task<RoleDTO> GetRole(Guid roleId, Guid userId)
    {
        if (userId == Guid.Empty || roleId == Guid.Empty)
            throw new Exception("");

        var user = await _userManager.FindByIdAsync(userId.ToString());

        if (user == null)
            throw new Exception("");

        var resultRole = await _roleManager.FindByIdAsync(roleId.ToString());

        if (resultRole == null)
            throw new Exception("");

        return resultRole.Adapt<RoleDTO>();
    }

    public async Task<PaginatedList<RoleDTO>> GetRoleListAsPagination(int pagesize, int pageindex, string searchName)
    {
        List<Role> roles = await _roleManager.Roles.Select(r => r.Adapt<Role>()).ToListAsync();

        if (!string.IsNullOrEmpty(searchName))
            roles = roles.Where(c => c.Name.Contains(searchName)).ToList();

        PaginatedList<Role> data = PaginatedList<Role>.Create(roles, pageindex, pagesize);
        return new PaginatedList<RoleDTO>(data.Select(c => c.Adapt<RoleDTO>()).ToList(), roles.Count(), pageindex, pagesize);
    }

    public async Task<bool> UpdateRole(RoleDTO role, Guid userId)
    {
        if (userId == Guid.Empty || role.Id == Guid.Empty)
            throw new Exception("");

        var user = await _userManager.FindByIdAsync(userId.ToString());

        if (user == null)
            throw new Exception("");

        var resultRole = await _roleManager.FindByIdAsync(role.Id.ToString());
        bool isValid = false;
        if(resultRole != null)
        {
            resultRole.Name = role.Name;
            resultRole.RoleDescription = role.RoleDescription;
            resultRole.UpdatedUserId = role.UpdatedUserId;            
            await _roleManager.UpdateAsync(resultRole);
            
            isValid = true;
        }

        return isValid;
    }
}

using DataTransferObject.DTOClasses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.ServiceInterfaces;
using System.Security.Claims;

namespace App.Web.Controllers;

[Authorize (Roles = "Admin")]
public class RoleController : Controller
{
    private readonly IRoleService _roleService;

    public RoleController(IRoleService roleService)
    {
        _roleService = roleService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(int? pageindex, string searchName)
    {
        var data = await _roleService.GetRoleListAsPagination(3, pageindex.HasValue ? pageindex.Value : 1, searchName);
        return View(data);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(RoleDTO role)
    {
        if(ModelState.IsValid)
        {
            try
            {
                await _roleService.AddRole(role, new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier) ?? Guid.Empty.ToString()));
                TempData["SuccessMessage"] = "CreateRole Successful";
                return LocalRedirect("/Role/GetAll");
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
            }
        }
        return LocalRedirect("/Role/GetAll");
    }

    [HttpGet]
    public async Task<IActionResult> Edit(Guid id)
    {
        var data = await _roleService.GetRole(id, new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier) ?? Guid.Empty.ToString()));
        return View(data);
    }
    [HttpPost]
    public async Task<IActionResult> EditAsync(RoleDTO role)
    {
        if (ModelState.IsValid)
        {
            var guid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            try
            {
                role.UpdateRole(new Guid(guid));
                await _roleService.UpdateRole(role, new Guid(guid));
                TempData["SuccessMessage"] = "UpdateRole Successful";
                return LocalRedirect("/Role/GetAll");
            } 
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
            }
        }
        return LocalRedirect("/Role/GetAll");
    }

    [HttpGet]
    public async Task<IActionResult> Delete(Guid id)
    {
        try
        {
            await _roleService.DeleteRole(id, new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier) ?? Guid.Empty.ToString()));
            TempData["SuccessMessage"] = "DeleteRole Successful";
            return LocalRedirect("/Role/GetAll");
        } 
        catch (Exception ex)
        {
            ViewData["ErrorMessage"] = ex.Message;
        }
        return LocalRedirect("/Role/GetAll");
        
    }
    


}

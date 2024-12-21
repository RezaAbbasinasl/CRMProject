using DataTransferObject.DTOClasses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.ServicClasses;
using Service.ServiceInterfaces;
using Shared;
using System.Security.Claims;

namespace App.Web.Controllers;
[Authorize (Roles ="Admin")]
public class DepartementController : Controller
{
    private readonly IDepartementService _departementService;

    public DepartementController(IDepartementService departementService)
    {
        _departementService = departementService;
    }
    [HttpGet]
    public async Task<IActionResult> GetAll(int? pageindex, string searchName)
    {
        var data =  await _departementService.GetDepartementListAsPagination(3, pageindex.HasValue ? pageindex.Value : 1, searchName);
        return View(data);
        
    }
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> CreateAsync(DepartementDTO departement)
    {
        if(ModelState.IsValid)
        {
            try
            {
                await _departementService.AddDepartement(departement);
                TempData["SuccessMessage"] = "CreateNewDepartement Successful";
                return LocalRedirect("/Departement/GetAll");
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
            }
        }
        return View(nameof(Create));
    }
    [HttpGet]
    public async Task<IActionResult> Edit(Guid id)
    {
        var departement =  await _departementService.GetDepartement(id.ToString());

        return View(departement);
    }
    [HttpPost]
    public async Task<IActionResult> EditAsync(DepartementDTO departement)
    {
        if(ModelState.IsValid)
        {
            try
            {
                await _departementService.UpdateDepartement(departement,new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier) ?? Guid.Empty.ToString()));
                TempData["SuccessMessage"] = "UpdateDepartement Successful";
                return LocalRedirect("/Departement/GetAll");
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
            }
        }
        return LocalRedirect("/Departement/GetAll");
    }    
    [HttpGet]
    public async Task<IActionResult> Delete(Guid id)
    {
        try
        {
            await _departementService.DeleteDepartement(id, new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier) ?? Guid.Empty.ToString()));
            TempData["SuccessMessage"] = "DeleteDepartement Successful";
            return LocalRedirect("/Departement/GetAll");
        }
        catch (Exception ex)
        {
            ViewData["ErrorMessage"] = ex.Message;
        }
        return LocalRedirect("/Departement/GetAll");
    }
}

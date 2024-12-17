using DataTransferObject.DTOClasses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.ServiceInterfaces;

namespace App.Web.Controllers;
[Authorize]
public class DepartementController : Controller
{
    private readonly IDepartementService _departementService;

    public DepartementController(IDepartementService departementService)
    {
        _departementService = departementService;
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> CreatePostAsync(DepartementDTO departement)
    {
        if(ModelState.IsValid)
        {
            try
            {
                await _departementService.AddDepartement(departement);
                TempData["SuccessMessage"] = "CreateNewDepartement Successful";
                return LocalRedirect("/Home/index");
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
            }
        }
        return View(nameof(Create));
    }
}

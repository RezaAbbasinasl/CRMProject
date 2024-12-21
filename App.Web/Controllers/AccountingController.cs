using DataTransferObject.DTOClasses;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.ServiceInterfaces;

namespace App.Web.Controllers;

public class AccountingController : Controller
{
    private readonly IUserService _userService;

    public AccountingController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> LoginPostAsync(LoginDTO login)
    {
        if (ModelState.IsValid)
        {
            var result = await _userService.LoginAsync(login);
            if (result)
            {
                TempData["SuccessMessage"] = "Logged in Successfully";
                return LocalRedirect("/Home/Index");
            }                    
        }
        ViewData["ErrorMessage"] = "Login Failed";
        return View("Login");
    }

    [HttpGet]
    public IActionResult Register() 
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> RegisterPostAsync(UserDTO user)
    {
        if(ModelState.IsValid)
        {
            try
            {                    
                var result = await _userService.RegisterAsync(user);
                TempData["SuccessMessage"] = "Registration Successful";

                return LocalRedirect("/Home/Index");
            } 
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
            }
        }
        return View("Register");
    }
    [Authorize]
    [HttpGet]
    public async Task<IActionResult> Logout()
    {
        var userName = User.Identity?.Name;
        if (!string.IsNullOrWhiteSpace(userName))
        {
            try
            {
                await _userService.LogoutAsync(userName);
                TempData["SuccessMessage"] = "Logout Successfully.";
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
            }
        }
        
        return LocalRedirect("/Home/Index");
    }
    [Authorize]
    [HttpGet]
    public async Task<ActionResult<EditProfileDTO>> EditProfile()
    {
        var user = await _userService.GetUser(User.Identity?.Name ?? "");
        var res = new EditProfileDTO();
        if (user != null)
        {
            res = user.Adapt<EditProfileDTO>();
        }
        return View(res);
    }
    [Authorize]
    [HttpPost]
    public async Task<IActionResult> EditProfileAsync(EditProfileDTO profile)
    {
        if (ModelState.IsValid)
        {            
            try
            {
                await _userService.UpdateAsync(profile, User.Identity?.Name ?? "");
                TempData["SuccessMessage"] = "User update completed";
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
            }
        }

        return View("EditProfile", profile);
    }
}

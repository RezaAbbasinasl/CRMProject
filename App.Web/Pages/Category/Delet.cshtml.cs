using DataTransferObject.DTOClasses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Model.Entities;
using Service.ServiceInterfaces;
using System.Security.Claims;

namespace App.Web.Pages.Category
{
    [Authorize]
    [BindProperties]
    public class DeletModel : PageModel
    {
        private readonly ICategoryService _categoryService;

        public DeletModel(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public async Task<IActionResult> OnGetAsync(Guid categoryId)
        {
            try
            {
                await _categoryService.DeleteCategory(categoryId, User.FindFirstValue(ClaimTypes.NameIdentifier) ?? Guid.Empty.ToString());
                TempData["SuccessMessage"] = "Category deleted successfully.";
                return RedirectToPage("/Category/Index");
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
            }

            return RedirectToPage("/Home/Index");
        }
    }
}

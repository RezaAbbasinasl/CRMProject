using DataTransferObject.DTOClasses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.ServiceInterfaces;
using System.Security.Claims;

namespace App.Web.Pages.Category;
[Authorize]
public class CreateCategoryModel : PageModel
{
    private readonly IDepartementService _departementService;
    private readonly ICategoryService _categoryService;
    
    public CreateCategoryModel(IDepartementService departementService, ICategoryService categoryService)
    {
        _departementService = departementService;
        _categoryService = categoryService;
    }

    [BindProperty]
    public InputModel Input { get; set; } = new InputModel();

    public class InputModel()
    {
        public CategoryDTO Category { get; set; }
        public List<DepartementDTO> Departements { get; set; } = new List<DepartementDTO>();
    }
    public async Task<IActionResult> OnGetAsync()
    {
        Input.Departements = await _departementService.AllDepartement(d => true);
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if(ModelState.IsValid)
        {
            var category = new CategoryDTO
            {
                Name = Input.Category.Name,
                DepartementId = Input.Category.DepartementId,
                Description = Input.Category.Description,                 
                CreateUserId = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier)),
            };

            try
            {
                await _categoryService.AddCategory(category);

                TempData["SuccessMessage"] = "CreateNewCategory Successful";
                return LocalRedirect("/Home/index");
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
            }                                   
        }        
        return Page();
    }
}

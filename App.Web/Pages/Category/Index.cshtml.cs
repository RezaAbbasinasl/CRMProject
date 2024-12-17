using DataTransferObject.DTOClasses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.ServiceInterfaces;
using Shared;
using System.Security.Claims;

namespace App.Web.Pages.Category
{
    [Authorize]    
    public class IndexModel : PageModel
    {

        private readonly ICategoryService _categoryService;

        public IndexModel(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [BindProperty]
        public PaginatedList<CategoryDTO> PaginatedList { get; set; }

        public async Task OnGetAsync(int? pageindex, string searchName)
        {
            PaginatedList = await _categoryService.GetCategoryListAsPagination(3, pageindex.HasValue ? pageindex.Value : 1, searchName);
        }        
    }
}

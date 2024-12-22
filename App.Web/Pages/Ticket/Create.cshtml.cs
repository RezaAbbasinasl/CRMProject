using DataTransferObject.DTOClasses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.ServiceInterfaces;
using System.Security.Claims;

namespace App.Web.Pages.Ticket
{
    [Authorize]
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly ITicketService _ticketService;
        private readonly ICategoryService _categoryService;

        public CreateModel(ITicketService ticketService, ICategoryService categoryService)
        {
            _ticketService = ticketService;
            _categoryService = categoryService;
        }

        public InputModel Input { get; set; } = new InputModel();
        public class InputModel
        {
            public TicketDTO? TicketModel { get; set; }
            public List<CategoryDTO> Categories { get; set; } 
        }
        public async Task<IActionResult> OnGetAsync()
        {
            Input.Categories = await _categoryService.AllCategory();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var ticket = new TicketDTO()
            {
                Subject = Input.TicketModel.Subject,
                Description = Input.TicketModel.Description,
                CreateUserId = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier) ?? Guid.Empty.ToString()),
                AuthorId = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier) ?? Guid.Empty.ToString()),
                CategoryId = Input.TicketModel.CategoryId,
            };
            try
            {
                await _ticketService.CreateTicket(ticket);

                TempData["SuccessMessage"] = "CreateNewTicket Successful";
                return LocalRedirect("/Ticket/GetAllByUserId");
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
            }
            return Page();
        }
    }
}

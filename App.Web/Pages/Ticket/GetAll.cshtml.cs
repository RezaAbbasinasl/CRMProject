using DataTransferObject.DTOClasses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.ServiceInterfaces;
using Shared;

namespace App.Web.Pages.Ticket
{
    [Authorize(Roles = "Admin")]
    [BindProperties]
    public class GetAllModel : PageModel
    {
        private readonly ITicketService _ticketService;

        public GetAllModel(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        public PaginatedList<TicketDTO> Input { get; set; }

        public async Task<IActionResult> OnGetAsync(int? pageindex, string searchName)
        {
            Input = await _ticketService.GetTicketListAsPagination(3, pageindex.HasValue ? pageindex.Value : 1, searchName);

            return Page();

        }
    }
}

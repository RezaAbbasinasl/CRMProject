using DataTransferObject.DTOClasses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.ServiceInterfaces;
using Shared;
using System.Security.Claims;

namespace App.Web.Pages.Ticket;
[Authorize]
public class GetAllByUserIdModel : PageModel
{
    private readonly ITicketService _ticketService;

    public GetAllByUserIdModel(ITicketService ticketService)
    {
        _ticketService = ticketService;
    }

    public List<TicketDTO> Input { get; set; }

    public async Task<IActionResult> OnGetAsync()
    {
        Input = await _ticketService.AllTickt(t => t.AuthorId == new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier) ?? Guid.Empty.ToString()));

        return Page();

    }
}

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
    public class ChatModel : PageModel
    {
        private readonly IMessageService _messageService;

        public ChatModel(IMessageService messageService)
        {
            _messageService = messageService;
        }
        public List<MessageDTO> Input { get; set; }
        public MessageDTO ResultMessage { get; set; }


        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            try
            {
                ViewData["GuidUserId"] = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? Guid.Empty.ToString();
                Input = await _messageService.AllMessageByTicketId(id);
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
                return LocalRedirect("Ticket/GetAll");
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(Guid id)
        {
            try
            {
                await _messageService.AddMessage(ResultMessage, new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier) ?? Guid.Empty.ToString()), id);

                TempData["SuccessMessage"] = "CreateNewMessage Successful";
                return LocalRedirect($"/Ticket/Chat?id={ResultMessage.TicketId}");
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
            }

            return Page();
        }        
    }
}

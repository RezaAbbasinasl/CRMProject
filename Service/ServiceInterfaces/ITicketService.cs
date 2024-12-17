using DataTransferObject.DTOClasses;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.ServiceInterfaces;

public interface ITicketService
{
    Task<bool> CreateTicket(TicketDTO ticket);
    Task<bool> DeleteTicket(Guid userId, Guid ticketId);
    Task<List<TicketDTO>> AllTickt(Expression<Func<Ticket, bool>> predicate);
    Task<Ticket> GetTicket(Guid userId, Guid ticketId);
}

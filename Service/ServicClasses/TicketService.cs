using DataTransferObject.DTOClasses;
using Infrastructure.RepositoryPattern;
using Infrastructure.RepositoryPattern.Interfaces;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Model.Entities;
using Service.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.ServicClasses;

public class TicketService : ITicketService
{
    private readonly ITicketRepository _ticketRepository;
    private readonly UserManager<Ticket> _userManager;

    public TicketService(ITicketRepository ticketRepository, UserManager<Ticket> userManager)
    {
        _ticketRepository = ticketRepository;
        _userManager = userManager;
    }

    public async Task<List<TicketDTO>> AllTickt(Expression<Func<Ticket, bool>> predicate = null)
    {
        var tickets = await _ticketRepository.QueryAsync(predicate ?? (t => true), include: t => t.Include(x => x.Author)
                                                                                                    .Include(x => x.Messages));

        return tickets.Select(x => x.Adapt<TicketDTO>()).ToList();
    }

    public async Task<bool> CreateTicket(TicketDTO ticket)
    {
        var user = _userManager.FindByIdAsync(ticket.Id.ToString());
        if (user == null)
            throw new Exception("");

        bool isValid = true;
        var result = await _ticketRepository.CreateDataAsync(ticket.Adapt<Ticket>());

        if (result == null)
            isValid = false;

        return isValid;
    }

    public async Task<bool> DeleteTicket(Guid userId, Guid ticketId)
    {
        bool isValid = false;

        if (userId == Guid.Empty)
            throw new Exception("");

        var user = await _userManager.FindByIdAsync(userId.ToString());

        if (user == null)
            throw new Exception("");

        var ticket = await _ticketRepository.GetAsync(ticketId);

        if (ticket != null)
        {
            await _ticketRepository.DeleteDataAsync(ticket.Id);
            isValid = true;
        }
        return isValid;
    }

    public async Task<Ticket> GetTicket(Guid userId, Guid ticketId)
    {
        var user = await _userManager.FindByIdAsync(userId.ToString());        

        if (user == null)
            throw new Exception("");

        var ticket = await _ticketRepository.GetAsync(ticketId);

        if (ticket == null)
            throw new Exception("");

        return ticket;
    }
}

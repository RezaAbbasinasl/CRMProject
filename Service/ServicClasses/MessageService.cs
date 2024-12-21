using DataTransferObject.DTOClasses;
using Infrastructure.RepositoryPattern;
using Infrastructure.RepositoryPattern.Interfaces;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Model.Entities;
using Service.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Service.ServicClasses;

public class MessageService : IMessageService
{
    private readonly IMessageRepository _messageRepository;
    private readonly UserManager<User> _userManager;  
    private readonly ITicketService _ticketService;

    public MessageService(IMessageRepository messageRepository, UserManager<User> userManager, ITicketService ticketService)
    {
        _messageRepository = messageRepository;
        _userManager = userManager;
        _ticketService = ticketService;
    }

    public async Task<bool> AddMessage(MessageDTO message, Guid userId, Guid ticketId)
    {
        message.CreateUserId = userId;
        message.AthureId = userId;
        message.TicketId = ticketId;
        var result = await _messageRepository.CreateDataAsync(message.Adapt<Message>());

        bool isValid = true;
        if (result == null)
        {
            isValid = false;
            throw new Exception("Message not created.");
        }

        return isValid;            
    }

    public async Task<List<MessageDTO>> AllMessageByTicketId(Guid ticketId)
    {
        if(ticketId == Guid.Empty) 
            throw new Exception("The ticketId is incorrect");

        var messages = await _messageRepository.QueryAsync(x => x.TicketId == ticketId);

        if (messages == null)
            messages = new List<Message>();

        return messages.Select(x => x.Adapt<MessageDTO>()).ToList();
    }

    public async Task<List<MessageDTO>> AllMessageByUserId(Guid userId, Guid ticketId)
    {
        if (userId == Guid.Empty || ticketId == Guid.Empty)
            throw new Exception("The user ID or ticket ID is incorrect.");

        var user = await _userManager.FindByIdAsync(userId.ToString());

        if (user == null)
            throw new Exception("User not found.");

        var ticket = await _ticketService.GetTicket(userId, ticketId);

        if (ticket == null)
            throw new Exception("Ticket not found.");

        var messages = await _messageRepository.QueryAsync(x => x.AthureId == userId && x.TicketId == ticketId);

        return messages.Select(x => x.Adapt<MessageDTO>()).ToList();
    }
}

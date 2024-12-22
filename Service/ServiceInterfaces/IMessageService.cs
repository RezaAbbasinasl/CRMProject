using DataTransferObject.DTOClasses;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ServiceInterfaces;

public interface IMessageService 
{
    Task<bool> AddMessage(MessageDTO message, Guid userId, Guid ticketId);
    Task<List<MessageDTO>> AllMessageByTicketId(Guid ticketId);
    Task<List<MessageDTO>> AllMessageByUserId(Guid userId,Guid ticketId);

}

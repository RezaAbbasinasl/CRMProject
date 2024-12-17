using DataTransferObject.DTOClasses;
using Infrastructure.RepositoryPattern;
using Model.Entities;
using Service.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ServicClasses;

public class MessageService : IMessageService
{
    private readonly IBaseRepository<Message> _Messagerepository;

    public MessageService(IBaseRepository<Message> messagerepository)
    {
        _Messagerepository = messagerepository;
    }

    public Task<bool> AddMessage(MessageDTO message)
    {
        throw new NotImplementedException();
    }

    public Task<List<MessageDTO>> AllMessage(Guid userId)
    {
        throw new NotImplementedException();
    }
}

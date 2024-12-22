using Infrastructure.RepositoryPattern.Interfaces;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.RepositoryPattern.Classes
{
    public class MessageRepository : BaseRepository<Message>, IMessageRepository
    {
        public MessageRepository(CRMDbContext dbContext) : base(dbContext)
        {
        }
    }
}

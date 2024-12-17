﻿using Infrastructure.RepositoryPattern.Interfaces;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.RepositoryPattern.Classes;

public class TicketRepository : BaseRepository<Ticket>, ITicketRepository
{
    public TicketRepository(CRMDbContext dbContext) : base(dbContext)
    {
    }
}

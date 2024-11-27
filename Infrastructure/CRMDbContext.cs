using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure;

public class CRMDbContext : IdentityDbContext<User, Role, Guid>
{
    public CRMDbContext() { }
    public CRMDbContext(DbContextOptions<CRMDbContext> dbContext) : base(dbContext) { }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Departement> Departements { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<Ticket> Tickets { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Data Source=.\\SQL2022;Initial Catalog=CRM_TestDB;Integrated Security=True;TrustServerCertificate=True");
        }
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}

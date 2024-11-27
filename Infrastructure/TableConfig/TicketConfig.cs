using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Entities;
using Shared.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.TableConfig
{
    internal class TicketConfig : BaseEntityTypeConfiguration<Ticket, Guid>
    {
        public override void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.ToTable(nameof(Ticket));

            base.RequiredTraceable = false;
            base.UseForTraceable = true;
            base.GeneratedValueForKey = true;
            base.Configure(builder);

            builder.Property(t => t.Subject).IsRequired(false).HasColumnType(SqlDbType.NVarChar.ToString()).HasMaxLength(300);
            builder.Property(t => t.Description).IsRequired().HasColumnType(SqlDbType.NVarChar.ToString()).HasMaxLength(600);
            builder.Property(t => t.ScoringDescription).IsRequired(false).HasColumnType(SqlDbType.NVarChar.ToString()).HasMaxLength(300);
            builder.Property(t => t.StatusId).IsRequired().HasDefaultValue(Statuss.Open);            
            builder.Property(t => t.PriorityId).IsRequired().HasDefaultValue(Prioritys.Medium);            
            builder.Property(t => t.ScoringId).IsRequired().HasDefaultValue(Scoring.none);            

            builder.HasOne(t => t.Category).WithMany(t => t.Tickets).HasForeignKey(t => t.CategoryId).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(t => t.Messages).WithOne(t => t.Ticket).HasForeignKey(t => t.TicketId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}

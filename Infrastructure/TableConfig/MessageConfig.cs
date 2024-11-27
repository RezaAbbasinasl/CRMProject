using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.TableConfig;

internal class MessageConfig : BaseEntityTypeConfiguration<Message, Guid>
{
    public override void Configure(EntityTypeBuilder<Message> builder)
    {
        builder.ToTable(nameof(Message));

        base.RequiredTraceable = false;
        base.UseForTraceable = true;
        base.GeneratedValueForKey = true;
        base.Configure(builder);

        builder.Property(m => m.Content).IsRequired().HasColumnType(SqlDbType.NVarChar.ToString()).HasMaxLength(600);

        builder.HasOne(m => m.Athure).WithMany(m => m.Messages).HasForeignKey(m => m.AthureId).OnDelete(DeleteBehavior.NoAction);
    }
}

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

internal class RoleConfig : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable(nameof(Role));
        builder.Property(r => r.RolePersianName).IsRequired(false).HasColumnType(SqlDbType.NVarChar.ToString()).HasMaxLength(200);
        builder.Property(r => r.RoleDescription).IsRequired(false).HasColumnType(SqlDbType.NVarChar.ToString()).HasMaxLength(300);
        builder.Property(u => u.CreatedDataTime).HasDefaultValue<DateTime>(DateTime.Now);
        builder.Property(u => u.UpdatedDataTime).IsRequired(false);

        builder.HasOne(u => u.CreatedUser).WithMany().HasForeignKey(u => u.CreatedUserId).IsRequired().OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(u => u.UpdatedUser).WithMany().HasForeignKey(u => u.UpdatedUserId).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
    }
}

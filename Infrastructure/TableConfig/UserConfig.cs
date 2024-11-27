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

internal class UserConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable(nameof(User));
        builder.Property(u => u.FirstName).IsRequired().HasColumnType(SqlDbType.NVarChar.ToString()).HasMaxLength(200);
        builder.Property(u => u.LastName).IsRequired().HasColumnType(SqlDbType.NVarChar.ToString()).HasMaxLength(200);
        builder.Property(u => u.IsActive).IsRequired().HasDefaultValue<bool>(true);
        builder.Property(u => u.CreatedDataTime).HasDefaultValue<DateTime>(DateTime.Now);
        builder.Property(u => u.UpdatedDataTime).IsRequired(false);
        builder.Property(u => u.DepartementId).IsRequired(false);

        builder.HasOne(u => u.CreatedUser).WithMany().HasForeignKey(u => u.CreatedUserId).IsRequired().OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(u => u.UpdatedUser).WithMany().HasForeignKey(u => u.UpdatedUserId).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(u => u.Departement).WithMany(u => u.Users).HasForeignKey(u => u.DepartementId).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
        builder.HasMany(u => u.Tickets).WithOne(u => u.Author).HasForeignKey(u => u.AuthorId).IsRequired().OnDelete(DeleteBehavior.NoAction);
    }
}

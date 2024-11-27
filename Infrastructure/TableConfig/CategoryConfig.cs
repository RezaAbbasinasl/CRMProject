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

internal class CategoryConfig : BaseEntityTypeConfiguration<Category,Guid>
{
    public override void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable(nameof(Category));

        base.UseForTraceable = true;
        base.RequiredTraceable = false;
        base.GeneratedValueForKey = true;
        base.Configure(builder);

        builder.Property(c => c.Name).IsRequired().HasColumnType(SqlDbType.NVarChar.ToString()).HasMaxLength(200);
        builder.Property(c => c.Description).IsRequired().HasColumnType(SqlDbType.NVarChar.ToString()).HasMaxLength(400);

        builder.HasOne(c => c.Departement).WithMany(c => c.Categories).HasForeignKey(c => c.DepartementId).OnDelete(DeleteBehavior.NoAction);
    }
}

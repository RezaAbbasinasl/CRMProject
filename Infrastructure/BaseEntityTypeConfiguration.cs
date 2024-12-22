using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure;

internal class BaseEntityTypeConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseEntity
{
    protected bool GeneratedValueForKey { get; set; } = true;

    protected bool UseForTraceable { get; set; } = false;

    protected bool RequiredTraceable { get; set; } = false;

    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder.HasKey(x => x.Id);
        if (GeneratedValueForKey)
        {
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
        }

        if (UseForTraceable == false)
        {
            builder.Ignore(x => x.CreatedDataTime);
            builder.Ignore(x => x.UpdatedDataTime);
            builder.Ignore(x => x.CreatedUserId);
            builder.Ignore(x => x.CreatedUser);
            builder.Ignore(x => x.UpdatedUserId);
            builder.Ignore(x => x.UpdatedUser);
        }
        else
        {
            builder.Property(x => x.CreatedDataTime).IsRequired(RequiredTraceable);
            builder.Property(x => x.UpdatedDataTime).IsRequired(RequiredTraceable);
            builder.HasOne(x => x.CreatedUser).WithMany().HasForeignKey(x => x.CreatedUserId).IsRequired(RequiredTraceable).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.UpdatedUser).WithMany().HasForeignKey(x => x.UpdatedUserId).IsRequired(RequiredTraceable).OnDelete(DeleteBehavior.NoAction);
        }
    }
}

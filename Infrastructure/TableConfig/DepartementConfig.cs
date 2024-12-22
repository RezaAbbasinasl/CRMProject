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

internal class DepartementConfig : BaseEntityTypeConfiguration<Departement>
{
    public override void Configure(EntityTypeBuilder<Departement> builder)
    {
        builder.ToTable(nameof(Departement));

        base.UseForTraceable = true; 
        base.RequiredTraceable = false;
        base.GeneratedValueForKey = true;
        base.Configure(builder);

        builder.Property(d => d.Name).IsRequired().HasColumnType(SqlDbType.NVarChar.ToString()).HasMaxLength(200);
        builder.Property(d => d.Description).IsRequired().HasColumnType(SqlDbType.NVarChar.ToString()).HasMaxLength(400);
    }
}

using AccessControlSystem.DataAccess.FluentConfigurations.Common;
using AccessControlSystem.Domain.Entities.Units;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessControlSystem.DataAccess.FluentConfigurations.Units
{
    public class UnitEntityTypeConfiguration:
        IEntityTypeConfiguration<Unit>
    {
        public  void Configure(EntityTypeBuilder<Unit> builder)
        {
            builder.ToTable("Units");
            
        }
    }
}

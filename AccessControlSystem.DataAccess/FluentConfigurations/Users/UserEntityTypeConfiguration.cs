using AccessControlSystem.DataAccess.FluentConfigurations.Common;
using AccessControlSystem.Domain.Entities.Units;
using AccessControlSystem.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessControlSystem.DataAccess.FluentConfigurations.Users
{
    public class UserEntityTypeConfiguration:
        IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasAlternateKey(x => x.CI);
            builder.OwnsOne(x => x.Contact);
            builder.OwnsOne(x => x.Location);

        }
    }
}

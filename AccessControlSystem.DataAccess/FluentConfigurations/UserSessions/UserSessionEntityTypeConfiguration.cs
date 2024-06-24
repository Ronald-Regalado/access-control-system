using AccessControlSystem.DataAccess.FluentConfigurations.Common;
using AccessControlSystem.Domain.Entities.UserSchedules;
using AccessControlSystem.Domain.Entities.UserSessions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessControlSystem.DataAccess.FluentConfigurations.UserSessions
{
    public class UserSessionEntityTypeConfiguration:
        IEntityTypeConfiguration<UserSession>
    {
        public void Configure(EntityTypeBuilder<UserSession> builder)
        {
            builder.ToTable("Sessions");
            builder.HasOne(x => x.User).WithMany().HasForeignKey(x => x.UserId);
            builder.HasOne(x => x.BusyUnit).WithMany().HasForeignKey(x => x.UnitId);


        }
    }
}

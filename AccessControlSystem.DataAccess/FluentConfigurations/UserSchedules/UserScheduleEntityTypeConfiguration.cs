using AccessControlSystem.DataAccess.FluentConfigurations.Common;
using AccessControlSystem.Domain.Entities.Users;
using AccessControlSystem.Domain.Entities.UserSchedules;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessControlSystem.DataAccess.FluentConfigurations.UserSchedules
{
    public class UserScheduleEntityTypeConfiguration:
       IEntityTypeConfiguration<UserSchedule>
    {
        public void Configure(EntityTypeBuilder<UserSchedule> builder)
        {
            builder.ToTable("Schedules");
            builder.HasOne(x => x.User).WithOne();
            //TODO: poder mapear la propiedad diccionario;
            builder.Property(x => x.Schedule).HasConversion
                (
                j => JsonConvert.SerializeObject(j,Formatting.None),
                d=>JsonConvert.DeserializeObject<Dictionary<DateTime,string>>(d)
                );

        }
    }
}

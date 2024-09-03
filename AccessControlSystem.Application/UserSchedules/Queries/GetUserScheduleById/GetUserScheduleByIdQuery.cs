using AccessControlSystem.Application.Abstract;
using AccessControlSystem.Domain.Entities.UserSchedules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessControlSystem.Application.UserSchedules.Queries.GetUserScheduleById
{
   public record GetUserScheduleByIdQuery(Guid id): IQuery<UserSchedule?>;
}

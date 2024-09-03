using AccessControlSystem.Application.Abstract;
using AccessControlSystem.Domain.Entities.Users;
using AccessControlSystem.Domain.Entities.UserSchedules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AccessControlSystem.Application.UserSchedules.Commands.CreateUserSchedule
{
    public record CreateUserScheduleCommand(User user) : ICommand<UserSchedule>;
}

using AccessControlSystem.Application.Abstract;
using AccessControlSystem.Domain.Entities.UserSchedules;

namespace AccessControlSystem.Application.UserSchedules.Commands.UpdateUserSchedule
{
    public record UpdateUserScheduleCommand(UserSchedule userSchedule) : ICommand;
}
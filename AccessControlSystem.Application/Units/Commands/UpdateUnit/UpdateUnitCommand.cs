using AccessControlSystem.Application.Abstract;
using AccessControlSystem.Domain.Entities.Units;

namespace AccessControlSystem.Application.Units.Commands.UpdateUnit
{
    public record UpdateUnitCommand(Unit unit) : ICommand;
}

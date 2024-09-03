using AccessControlSystem.Application.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AccessControlSystem.Domain.Entities.Units;

namespace AccessControlSystem.Application.Units.Commands.CreateUnit
{
    public record CreateUnitCommand(string maker, string code) : ICommand<Unit>;
}

using AccessControlSystem.Application.Abstract;
using AccessControlSystem.Domain.Entities.Units;
using AccessControlSystem.Domain.Entities.Users;
using AccessControlSystem.Domain.Entities.UserSessions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AccessControlSystem.Application.UserSessions.Commands.CreateUserSession
{
   public record CreateUserSessionCommand(User user,Unit unit) :ICommand<UserSession>;
}

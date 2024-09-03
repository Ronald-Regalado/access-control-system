using AccessControlSystem.Application.Abstract;
using AccessControlSystem.Domain.Entities.UserSessions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessControlSystem.Application.UserSessions.Commands.UpdateUserSession
{
    public record UpdateUserSessionCommand(UserSession userSession): ICommand;
   
}

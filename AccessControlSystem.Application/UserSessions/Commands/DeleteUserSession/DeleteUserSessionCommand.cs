using AccessControlSystem.Application.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessControlSystem.Application.UserSessions.Commands.DeleteUserSession
{
    public record DeleteUserSessionCommand(Guid id) : ICommand;
   
}

using AccessControlSystem.Application.Abstract;
using AccessControlSystem.Domain.Entities.UserSessions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessControlSystem.Application.UserSessions.Queries.GetUserSessionById
{
   public record GetUserSessionByIdQuery(Guid id): IQuery<UserSession?>;    
}

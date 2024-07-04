using AccessControlSystem.DataAccess.Contexts;
using AccessControlSystem.Contracts;
using AccessControlSystem.DataAccess.Repositories.Common;
using AccessControlSystem.Contracts.UserSessions;
using AccessControlSystem.Domain.Entities.UserSessions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessControlSystem.DataAccess.Repositories.UserSessions
{
    /// <summary>
    /// Implementación del repositorio <see cref="IUserSessionRepository"/>.
    /// </summary>
    public class UserSessionRepository
        : RepositoryBase, IUserSessionRepository
    {
        public UserSessionRepository(ApplicationContext context)
            : base(context) { }

        public void AddUserSession(UserSession userSession)
        {
            _context.Sessions.Add(userSession);
        }

        public void DeleteUserSession(UserSession userSession)
        {
            _context.Sessions.Remove(userSession);
        }

        public IEnumerable<UserSession> GetAllUserSessions()
        {
            return _context.Sessions.ToList();
        }

        public UserSession? GetUserSessionById(Guid id)
        {
            return _context.Sessions.FirstOrDefault(i => i.Id == id);
        }

        public void UpdateUserSession(UserSession userSession)
        {
            _context.Sessions.Update(userSession);
        }
    }
}

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
            _context.UserSessions.Add(userSession);
        }

        public void DeleteUserSession(UserSession userSession)
        {
            _context.UserSessions.Remove(userSession);
        }

        public IEnumerable<T> GetAllUserSessions<T>() where T : UserSession
        {
            return _context.Set<T>().ToList();
        }

        public T? GetUserSessionById<T>(Guid id) where T : UserSession
        {
            return _context.Set<T>().FirstOrDefault(i => i.Id == id);
        }

        public void UpdateUserSession(UserSession userSession)
        {
            _context.UserSessions.Update(userSession);
        }
    }
}

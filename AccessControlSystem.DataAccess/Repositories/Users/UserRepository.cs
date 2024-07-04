using AccessControlSystem.Contracts.Users;
using AccessControlSystem.DataAccess.Contexts;
using AccessControlSystem.DataAccess.Repositories.Common;
using AccessControlSystem.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessControlSystem.DataAccess.Repositories.Users
{
    /// <summary>
    /// Implementación del repositorio <see cref="IUnitRepository"/>.
    /// </summary>
    public class UserRepository
        : RepositoryBase, IUserRepository
    {
        public UserRepository(ApplicationContext context)
            : base(context) { }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
        }

        public void DeleteUser(User user)
        {
            _context.Users.Remove(user);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public User? GetUserById(Guid id) 
        {
            return _context.Users.FirstOrDefault(i => i.Id == id);
        }

        public void UpdateUser(User user)
        {
            _context.Users.Update(user);
        }
    }
}

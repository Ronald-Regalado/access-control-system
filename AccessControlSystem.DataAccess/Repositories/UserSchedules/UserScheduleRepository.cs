using AccessControlSystem.DataAccess.Contexts;
using AccessControlSystem.DataAccess.Repositories.Common;
using AccessControlSystem.Contracts.UserSchedules;
using AccessControlSystem.Domain.Entities.UserSchedules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessControlSystem.DataAccess.Repositories.UserSchedules
{
    /// <summary>
    /// Implementación del repositorio <see cref="IUserScheduleRepository"/>.
    /// </summary>
    public class UserScheduleRepository
        : RepositoryBase, IUserScheduleRepository
    {
        public UserScheduleRepository(ApplicationContext context)
            : base(context) { }

        public void AddUserSchedule(UserSchedule userSchedule)
        {
            _context.UserSchedules.Add(userSchedule);
        }

        public void DeleteUserSchedule(UserSchedule userSchedule)
        {
            _context.UserSchedules.Remove(userSchedule);
        }

        public IEnumerable<T> GetAllUserSchedules<T>() where T : UserSchedule
        {
            return _context.Set<T>().ToList();
        }

        public T? GetUserScheduleById<T>(Guid id) where T : UserSchedule
        {
            return _context.Set<T>().FirstOrDefault(i => i.Id == id);
        }

        public void UpdateUserSchedule(UserSchedule userSchedule)
        {
            _context.UserSchedules.Update(userSchedule);
        }
    }
}

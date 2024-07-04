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
            _context.Schedules.Add(userSchedule);
        }

        public void DeleteUserSchedule(UserSchedule userSchedule)
        {
            _context.Schedules.Remove(userSchedule);
        }

        public IEnumerable<UserSchedule> GetAllUserSchedules()
        {
            return _context.Schedules.ToList();
        }

        public UserSchedule? GetUserScheduleById(Guid id)
        {
            return _context.Schedules.FirstOrDefault(i => i.Id == id);
        }

        public void UpdateUserSchedule(UserSchedule userSchedule)
        {
            _context.Schedules.Update(userSchedule);
        }
    }
}

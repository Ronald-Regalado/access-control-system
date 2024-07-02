using AccessControlSystem.DataAccess.Contexts;
using AccessControlSystem.DataAccess.Repositories.Common;
using AccessControlSystem.Contracts.Units;
using AccessControlSystem.Domain.Entities.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessControlSystem.DataAccess.Repositories.Units
{
    /// <summary>
    /// Implementación del repositorio <see cref="IUnitRepository"/>.
    /// </summary>
    public class UnitRepository
        : RepositoryBase, IUnitRepository
    {
        public UnitRepository(ApplicationContext context)
            : base(context) { }

        public void AddUnit(Unit unit)
        {
            _context.UserSessions.Add(unit);
        }

        public void DeleteUnit(Unit unit)
        {
            _context.UserSessions.Remove(unit);
        }

        public IEnumerable<T> GetAllUnits<T>() where T : Unit
        {
            return _context.Set<T>().ToList();
        }

        public T? GetUnitById<T>(Guid id) where T : Unit
        {
            return _context.Set<T>().FirstOrDefault(i => i.Id == id);
        }

        public void UpdateUnit(Unit unit)
        {
            _context.UserSessions.Update(unit);
        }
    }
}

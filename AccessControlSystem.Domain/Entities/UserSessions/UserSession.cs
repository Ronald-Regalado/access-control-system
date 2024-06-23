using AccessControlSystem.Domain.Common;
using AccessControlSystem.Domain.Entities.Units;
using AccessControlSystem.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessControlSystem.Domain.Entities.UserSessions
{
    public class UserSession : Entity
    {
        #region Propierties
        /// <summary>
        /// Usuario
        /// </summary>
        public User User { get; set; }
        /// <summary>
        /// Identificador del usuario asociado
        /// </summary>
        public Guid UserId { get; set; }
        /// <summary>
        /// Equipo en uso
        /// </summary>
        public Unit BusyUnit { get; set; }
        /// <summary>
        /// Identificador de la unidad asociada
        /// </summary>
        public Guid UnitId { get; set; }
        /// <summary>
        /// Fecha de inicio de sesión
        /// </summary>
        public DateTime StartTime { get; }
        /// <summary>
        /// Fecha de fin de sesión
        /// </summary>
        public DateTime? EndTime { get; set; }
        #endregion
        /// <summary>
        /// Constructor del objeto sesión de usuario
        /// </summary>
        /// <param name="user"></param>
        /// <param name="busyUnit"></param>
        public UserSession(User user, Unit busyUnit, Guid id) : base(id)
        {
            User = user;
            BusyUnit = busyUnit;
            StartTime = DateTime.Now;
        }
        protected UserSession() { }
    }
}

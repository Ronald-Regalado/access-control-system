using AccessControlSystem.Domain.Common;
using AccessControlSystem.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessControlSystem.Domain.Entities.UserSchedules
{
    /// <summary>
    /// UserSchedule--planificacion de usuario
    /// </summary>
    public class UserSchedule : Entity
    {
        #region Properties
        /// <summary>
        /// Usuario
        /// </summary>
        public User User { get; set; }
        /// <summary>
        /// Identificador del usuario asociado
        /// </summary>
        public Guid UserId { get; set; }
        /// <summary>
        /// Horario del usuario y descripcion
        /// </summary>
      //  public Dictionary<DateTime, string>? Schedule { get; set; }
        #endregion

        /// <summary>
        /// Inicializa un objeto <see cref="UserSchedule"/>.
        /// </summary>
        /// <param name="user">Usuario.</param>
        public UserSchedule(User user, Guid id) : base(id)
        {
            User = user;
            // Schedule = new Dictionary<DateTime, string>();
        }
        protected UserSchedule() { }
    }
}

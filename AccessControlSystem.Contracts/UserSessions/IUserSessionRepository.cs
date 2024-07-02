using AccessControlSystem.Domain.Entities.UserSessions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessControlSystem.Contracts.UserSessions
{
    /// <summary>
    /// Describe las funcionalidades necesarias
    /// para dar persistencia a UserSession.
    /// </summary>
    public interface IUserSessionRepository
    {
        /// <summary>
        /// Añade una sesion de usuario al soporte de datos.
        /// </summary>
        /// <param name="userSession">sesion de usuario a añadir.</param>
        void AddUserSession(UserSession userSession);

        /// <summary>
        /// Obtiene una sesion de usuario del soporte de datos a partir de su identificador.
        /// </summary>
        /// <typeparam name="T">Tipo de sesion a obtener</typeparam>
        /// <param name="id">Identificador de la sesion.</param>
        /// <returns>sesion obtenida del soporte de datos; de no existir, <see langword="null"/>.</returns>
        T? GetUserSessionById<T>(Guid id) where T : UserSession;

        /// <summary>
        /// Obtiene todas las sesiones del soporte de datos.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IEnumerable<T> GetAllUserSessions<T>() where T : UserSession;

        /// <summary>
        /// Actualiza el valor de una sesion en el soporte de datos.
        /// </summary>
        /// <param name="userSession">Instancia con la información a actualizar del usuario.</param>
        void UpdateUserSession(UserSession userSession);

        /// <summary>
        /// Elimina un usuario del soporte de datos
        /// </summary>
        /// <param name="userSession">Cliente a eliminar.</param>
        void DeleteUserSession(UserSession userSession);
    }
}
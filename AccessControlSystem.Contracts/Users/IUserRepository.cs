using AccessControlSystem.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessControlSystem.Contracts.Users
{
    /// <summary>
    /// Describe las funcionalidades necesarias
    /// para dar persistencia a usuario.
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Añade un usuario al soporte de datos.
        /// </summary>
        /// <param name="user">Usuario a añadir.</param>
        void AddUser(User user);

        /// <summary>
        /// Obtiene un usuario del soporte de datos a partir de su identificador.
        /// </summary>
        /// <typeparam name="T">Tipo de usuario a obtener</typeparam>
        /// <param name="id">Identificador del User.</param>
        /// <returns>User obtenido del soporte de datos; de no existir, <see langword="null"/>.</returns>
        T? GetUserById<T>(Guid id) where T : User;

        /// <summary>
        /// Obtiene todos los usuarios del soporte de datos.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IEnumerable<T> GetAllUsers<T>() where T : User;

        /// <summary>
        /// Actualiza el valor de un usuario en el soporte de datos.
        /// </summary>
        /// <param name="user">Instancia con la información a actualizar del usuario.</param>
        void UpdateUser(User user);

        /// <summary>
        /// Elimina un cliente del soporte de datos
        /// </summary>
        /// <param name="user">Cliente a eliminar.</param>
        void DeleteUser(User user);
    }
}

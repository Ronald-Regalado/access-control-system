using AccessControlSystem.Domain.Entities.UserSchedules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessControlSystem.Contracts.UserSchedules
{
    /// <summary>
    /// Describe las funcionalidades necesarias
    /// para dar persistencia a UserSchedules.
    /// </summary>
    public interface IUserScheduleRepository
    {
        /// <summary>
        /// Añade una UserSchedule al soporte de datos.
        /// </summary>
        /// <param name="userSchedule">UserSchedule a añadir.</param>
        void AddUserSchedule(UserSchedule userSchedule);

        /// <summary>
        /// Obtiene una UserSchedule del soporte de datos a partir de su identificador.
        /// </summary>
        /// <typeparam name="T">Tipo de UserSchedule a obtener</typeparam>
        /// <param name="id">Identificador de la UserSchedule.</param>
        /// <returns>UserSchedule obtenida del soporte de datos; de no existir, <see langword="null"/>.</returns>
        T? GetUserScheduleById<T>(Guid id) where T : UserSchedule;

        /// <summary>
        /// Obtiene todas las UserSchedules del soporte de datos.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IEnumerable<T> GetAllUserSchedules<T>() where T : UserSchedule;

        /// <summary>
        /// Actualiza el valor de una UserSchedule en el soporte de datos.
        /// </summary>
        /// <param name="userSchedule">Instancia con la información a actualizar de la UserSchedule.</param>
        void UpdateUserSchedule(UserSchedule userSchedule);

        /// <summary>
        /// Elimina una UserSchedule del soporte de datos
        /// </summary>
        /// <param name="userSchedule">UserSchedule a eliminar.</param>
        void DeleteUserSchedule(UserSchedule userSchedule);
    }
}
using AccessControlSystem.Domain.Common;
using AccessControlSystem.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace AccessControlSystem.Domain.Entities.Users
{
    public class User : Entity
    {
        #region Propierties
        /// <summary>
        /// Nombre 
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Apellidos
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Carnet de identidad
        /// </summary>
        public string CI { get; set; }
        /// <summary>
        /// Direción de residencia del usuario
        /// </summary>
        public Location? Location { get; set; }
        /// <summary>
        /// Nivel de escolaridad del usuario
        /// </summary>
        public string? SchoolLevel { get; set; }
        /// <summary>
        /// Contacto del usuario(correo y teléfono)
        /// </summary>
        public Contact? Contact { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Constuctor inicializa un objeto User <see cref="User"/>.
        /// </summary>
        /// <param name="firstName">Nombre del usuario.</param>
        /// <param name="lastName">Apellidos del usuario.</param>
        /// <param name="ci">Carnet de identidad</param>
        public User(string firstName, string lastName, string ci, Guid id) : base(id)
        {
            FirstName = firstName;
            LastName = lastName;
            CI = ci;

        }

        protected User() { }
        /// <summary>
        /// Función para crear la entidad usuario pudiendo validar los parámetros de esta.
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="ci"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static User createUser(string firstName, string lastName, string ci, Guid id)
        {
           if(Regex.IsMatch(ci, @"^\d{11}$") && Regex.IsMatch(firstName, @"^[a-zA-Z\s]") && Regex.IsMatch(lastName, @"^[a-zA-Z\s]"))
            {
                return new User(firstName, lastName, ci, id);
            }
            else
            {
                return null;
            }
        }
        #endregion
    }
}

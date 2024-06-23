using AccessControlSystem.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessControlSystem.Domain.ValueObjects
{
    public class Contact : ValueObject
    {
        #region Propierties
        /// <summary>
        /// Correo electrónico
        /// </summary>
        public string Mail { get; set; }
        /// <summary>
        /// Número de teléfono
        /// </summary>
        public string Telephone { get; set; }
        #endregion

        /// <summary>
        /// Constuctor inicializa un objeto Contact <see cref="Contact"/>.
        /// </summary>
        /// <param name="mail">Correo elecrtónico del usuario.</param>
        /// <param name="telephone">Número de teléfono del usuario</param>
        public Contact(string mail, string telephone)
        {
            Mail = mail;
            Telephone = telephone;
        }
        protected Contact() { }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Mail;
            yield return Telephone;
        }
    }
}

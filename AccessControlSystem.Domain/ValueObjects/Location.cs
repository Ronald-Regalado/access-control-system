using AccessControlSystem.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessControlSystem.Domain.ValueObjects
{
    public class Location : ValueObject
    {
        #region Propierties
        /// <summary>
        /// Estado o provincia
        /// </summary>
        public string State { get; set; }
        /// <summary>
        /// Ciudad o municipio
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// Dirección local, calle y número etc
        /// </summary>
        public string Address { get; set; }
        #endregion

        /// <summary>
        /// Constuctor inicializa un objeto Location <see cref="Location"/>.
        /// </summary>
        /// <param name="state">Nombre del estado o provincia.</param>
        /// <param name="city">Nombre del estado o provincia.</param>
        /// <param name="address">Dirección local.</param>
        public Location(string state, string city, string address)
        {
            State = state;
            City = city;
            Address = address;
        }
        protected Location() { }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return State;
            yield return City;
            yield return Address;
        }
    }
}

using AccessControlSystem.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessControlSystem.Domain.Entities.Units
{
    public class Unit : Entity
    {
        #region properties

        /// <summary>
        /// maker--fabricante
        /// </summary>
        public string Maker { get; set; }
        /// <summary>
        /// code--identificador
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// producto producido
        /// </summary>
        public string? Product { get; set; }
        /// <summary>
        /// ver si esta en uso o no la unidad
        /// </summary>
        public bool IsInUse { get; set; }

        #endregion

        /// <summary>
        /// Inicializa un objeto <see cref="Unit"/>.
        /// </summary>
        /// <param name="maker">Fabricante.</param>
        /// <param name="code">Codigo alfanumerico.</param>
        public Unit(string maker, string code, Guid id) : base(id)
        {
            Maker = maker;
            Code = code;
            IsInUse = false;
        }

        protected Unit()
        {
        }
    }
}

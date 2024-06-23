namespace AccessControlSystem.Domain.Common
{
    public abstract class Entity
    {
        #region Properties

        /// <summary>
        /// Identificador en el soporte de datos.
        /// </summary>
        public Guid Id { get; set; }

        #endregion

        /// <summary>
        /// Requerido por EntityFramework.
        /// </summary>
        protected Entity() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">Identificador de la entidad.</param>
        protected Entity(Guid id)
        {
            Id = id;
        }
    }
}

using AccessControlSystem.DataAccess.FluentConfigurations.Units;
using AccessControlSystem.DataAccess.FluentConfigurations.Users;
using AccessControlSystem.DataAccess.FluentConfigurations.UserSchedules;
using AccessControlSystem.DataAccess.FluentConfigurations.UserSessions;
using AccessControlSystem.Domain.Entities.Units;
using AccessControlSystem.Domain.Entities.Users;
using AccessControlSystem.Domain.Entities.UserSchedules;
using AccessControlSystem.Domain.Entities.UserSessions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessControlSystem.DataAccess.Contexts
{
    public class ApplicationContext:DbContext
    {
        //Región destinada a la declaración de las tablas de las entidades base
        #region Tables
        /// <summary>
        /// Tabla de usuarios
        /// </summary>
        public DbSet<User> Users { get; set; }
        /// <summary>
        /// Tabla de unidades
        /// </summary>
        public DbSet<Unit> Units { get; set; }
        /// <summary>
        /// Tabla de sesiones de usuario
        /// </summary>
        public DbSet<UserSession> Sessions { get; set; }
        /// <summary>
        /// Tabla de horarios de usuario
        /// </summary>
        public DbSet<UserSchedule> Schedules { get; set; }
        #endregion

        #region Builders
        /// <summary>
        /// Requerido por EntityFrameworkCore para migraciones.
        /// </summary>
        public ApplicationContext()
        {
        }

        /// <summary>
        /// Inicializa un objeto <see cref="ApplicationContext"/>.
        /// </summary>
        /// <param name="connectionString">
        /// Cadena de conexión.
        /// </param>
        public ApplicationContext(string connectionString)
            : base(GetOptions(connectionString))
        {
        }

        /// <summary>
        /// Inicializa un objeto <see cref="ApplicationContext"/>.
        /// </summary>
        /// <param name="options">
        /// Opciones del contexto.
        /// </param>
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }
        #endregion

        #region Functions
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UnitEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UserScheduleEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UserSessionEntityTypeConfiguration());
        }
        #endregion

        #region Helpers

        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqliteDbContextOptionsBuilderExtensions.UseSqlite(new DbContextOptionsBuilder(), connectionString).Options;
        }

        #endregion
    }

    /// <summary>
    /// Habilita características en tiempo de diseño de la base de datos de la aplicación.
    /// Ej: Migraciones.
    /// </summary>
    public class ApplicationContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
        public ApplicationContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();

            try
            {
                var connectionString = "Data Source = CarDealerDB.sqlite";
                optionsBuilder.UseSqlite(connectionString);
            }
            catch (Exception)
            {
                //handle errror here.. means DLL has no sattelite configuration file.
                throw;
            }

            return new ApplicationContext(optionsBuilder.Options);
        }
    }
}

using AccessControlSystem.DataAccess.Contexts;
using AccessControlSystem.Domain.Entities.Units;
using AccessControlSystem.Domain.Entities.Users;
using AccessControlSystem.Domain.Entities.UserSchedules;
using AccessControlSystem.Domain.Entities.UserSessions;
using Microsoft.EntityFrameworkCore;

namespace AccessControlSystem.AppConsole
{
    public class Program
    {
        static void Main(string[] args)
        {
            if (File.Exists("Data.sqlite"))
                File.Delete("Data.sqlite");

            // Definiendo string de conexión.
            string connectionString = "Data Source = Data.sqlite";

            ApplicationContext applicationContext = new ApplicationContext(connectionString);
            if (!applicationContext.Database.CanConnect())
            {
                applicationContext.Database.Migrate();
            }

            //Creando entidades para la BD
            User user1 = new User("Ronald", "Regalado Batista", "01022065449", Guid.NewGuid());
            User user2 = new User("Carlos Daniel", "Fernández Ramos", "01027854223", Guid.NewGuid());

            Unit unit1 = new Unit("Siemens", "S0102", Guid.NewGuid());
            Unit unit2 = new Unit("Schnaider Electric", "SE2001", Guid.NewGuid());

            UserSession sesion = new UserSession(user1, unit1, Guid.NewGuid());
            UserSchedule schedule = new UserSchedule(user2, Guid.NewGuid());

            //Almacenando entidades en BD
            applicationContext.Users.Add(user1);
            applicationContext.Users.Add(user2);

            applicationContext.Units.Add(unit1);
            applicationContext.Units.Add(unit2);

            applicationContext.Sessions.Add(sesion);
            applicationContext.Schedules.Add(schedule);

            applicationContext.SaveChanges();

            //Lectura de BD
            User? userFronSession = applicationContext.Set<User>().FirstOrDefault(u => u.Id == sesion.UserId);
            Unit? unitFronSession = applicationContext.Set<Unit>().FirstOrDefault(u => u.Id == sesion.UnitId);

            //Actualización de BD
            unit2.Maker = "Siemens";

            applicationContext.Update(unit2);
            applicationContext.SaveChanges();

            Unit? modifiedUnit=applicationContext.Set<Unit>().FirstOrDefault(u=>u.Id == unit2.Id);
            Console.WriteLine($"Rectificada marca de la unidad #2 a{unit2.Maker}");

            //Eliminando entidad
            applicationContext.Remove(schedule);
            applicationContext.SaveChanges(true);
             UserSchedule? deletedSchedule= applicationContext.Set<UserSchedule>().FirstOrDefault(s => s.Id == schedule.Id);
        }
    }
}

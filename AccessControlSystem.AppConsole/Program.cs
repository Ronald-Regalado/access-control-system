using AccessControlSystem.DataAccess.Contexts;
using AccessControlSystem.DataAccess;
using AccessControlSystem.DataAccess.Repositories.Units;
using AccessControlSystem.DataAccess.Repositories.UserSchedules;
using AccessControlSystem.DataAccess.Repositories.UserSessions;
using AccessControlSystem.DataAccess.Repositories.Users;
using AccessControlSystem.Domain.Entities.Units;
using AccessControlSystem.Domain.Entities.Users;
using AccessControlSystem.Domain.Entities.UserSchedules;
using AccessControlSystem.Domain.Entities.UserSessions;
using AccessControlSystem.Contracts;
using AccessControlSystem.Contracts.Units;
using AccessControlSystem.Contracts.Users;
using AccessControlSystem.Contracts.UserSchedules;
using AccessControlSystem.Contracts.UserSessions;
using Microsoft.EntityFrameworkCore;

namespace AccessControlSystem.AppConsole
{
    internal class Program
    {
        static async Task Main(string[] args)
        {//Borrando Base de Datos
            if (File.Exists("Data.sqlite"))
                File.Delete("Data.sqlite");

            // Definiendo string de conexión.
            string connectionString = "Data Source = Data.sqlite";

            ApplicationContext applicationContext = new ApplicationContext(connectionString);
            if (!applicationContext.Database.CanConnect())
            {
                applicationContext.Database.Migrate();
            }
            //Creando instancias de repositorios y de UnitOfWork
            IUnitOfWork unitOfWork = new UnitOfWork(applicationContext);
            IUnitRepository unitRepository = new UnitRepository(applicationContext);
            IUserRepository userRepository = new UserRepository(applicationContext);
            IUserScheduleRepository userScheduleRepository = new UserScheduleRepository(applicationContext);
            IUserSessionRepository userSessionRepository = new UserSessionRepository(applicationContext);



            //Creando entidades para la BD
            User user1 = new User("Ronald", "Regalado Batista", "01022065449", Guid.NewGuid());
            User user2 = new User("Carlos Daniel", "Fernández Ramos", "01027854223", Guid.NewGuid());

            Unit unit1 = new Unit("Siemens", "S0102", Guid.NewGuid());
            Unit unit2 = new Unit("Schnaider Electric", "SE2001", Guid.NewGuid());

            UserSession sesion1 = new UserSession(user1, unit1, Guid.NewGuid());
            UserSession sesion2 = new UserSession(user2, unit1, Guid.NewGuid());
            UserSchedule schedule = new UserSchedule(user2, Guid.NewGuid());

            //Almacenando entidades en BD
            userRepository.AddUser(user1);
            userRepository.AddUser(user2);

            unitRepository.AddUnit(unit1);
            unitRepository.AddUnit(unit2);

            userSessionRepository.AddUserSession(sesion1);
            userSessionRepository.AddUserSession(sesion2);

            userScheduleRepository.AddUserSchedule(schedule);

            unitOfWork.SaveChanges();
            
            
            //Obteniendo entidades
            User? userA = userRepository.GetUserById(user1.Id);
            User? userB = userRepository.GetUserById(user2.Id);


            //Comprobando
            if (userA is null || userB is null)
                Console.WriteLine("Las entidades no se encontraron en BD.");
            else
            {
                Console.WriteLine($"Los usuario solicitados son {user1.FirstName}{user1.LastName}  y " +
                    $" {userB.FirstName} {userB.LastName}.");
            }
        

        
            

            //Actualización de BD
            //unit2.Maker = "Siemens";
            //schedule.Schedule.Add(DateTime.Now,"Se guardo correctamente");

           // unitRepository.UpdateUnit(unit2);
           // unitOfWork.SaveChanges();
           // Unit? modifiedUnit= unitRepository.GetUnitById(unit2);
            Console.WriteLine($"Rectificada marca de la unidad #2 a {unit2.Maker}");

            //Eliminando entidad
            unitRepository.DeleteUnit(unit2);
            unitOfWork.SaveChanges();

            Unit? deletedUnit = unitRepository.GetUnitById(unit2.Id);
            if (deletedUnit is null)
                Console.WriteLine("Unit successfully deleted");
        }
    }
}

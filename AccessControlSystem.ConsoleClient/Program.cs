using AccessControlSystem.Domain.Entities.Units;
using AccessControlSystem.Domain.Entities.Users;
using AccessControlSystem.GrpcServices.Protos;
using Grpc.Net.Client;
using Google.Protobuf.WellKnownTypes;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace AccessControlSystem.ConsoleClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
           

            Console.WriteLine("Presione una tecla para conectar");
            Console.ReadKey();

           Console.WriteLine("Creating channel and client");

            var httpHandler=new HttpClientHandler();
            httpHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
            var channel = GrpcChannel.ForAddress("http://localhost:5051", new GrpcChannelOptions { HttpHandler = httpHandler });


            var client = new AccessControlSystem.GrpcServices.Protos.Unit.UnitClient(channel);

            Console.WriteLine("Presione una tecla para crear un unidad");
             Console.ReadKey();
             var createResponse = client.CreateUnit(new CreateUnitRequest() 
             { 
                 Maker="Siemens",
                 Code="S2001"
             });

             if (createResponse is null)
             {
                 Console.WriteLine("Cannot create unit");
                 channel.Dispose();
                 return;
             }
             else
             {
                 Console.WriteLine($"Creación exitosa.");
             }

             Console.WriteLine("Presione una tecla para obtener todas las unidades");
             Console.ReadKey();
             var getResponse = client.GetAllUnits(new Google.Protobuf.WellKnownTypes.Empty());
             if (getResponse.Items is null)
             {
                 Console.WriteLine("Cannot get price");
                 channel.Dispose();
                 return;
             }
             else
             {
                 Console.WriteLine($"Obtención exitosa de {getResponse.Items.Count} Unidades");
             }

             Console.WriteLine($"Presione una tecla para obtener  con Id {createResponse.Id}");
             Console.ReadKey();
             var getByIdResponse = client.GetUnit(new GetRequest() { Id = createResponse.Id.ToString() });
             if (getByIdResponse is null)
             {
                 Console.WriteLine("Cannot get Unit");
                 channel.Dispose();
                 return;
             }
             else
             {
                 Console.WriteLine($"Obtención exitosa de la unidad {getByIdResponse.Unit.Maker} : {getByIdResponse.Unit.Code}");
             }

             Console.WriteLine("Presione una tecla para modificar la unidad");
             Console.ReadKey();
             createResponse.IsInUse = !createResponse.IsInUse;
             client.UpdateUnit(createResponse);

             var updatedGetResponse = client.GetUnit(new GetRequest() { Id = createResponse.Id });
             if (updatedGetResponse is not null && 
                 updatedGetResponse.KindCase == NullableUnitDTO.KindOneofCase.Unit && 
                 updatedGetResponse.Unit.IsInUse == createResponse.IsInUse)
             {
                 Console.WriteLine($"Modificación exitosa.");
             }
             
             Console.WriteLine("Presione una tecla para eliminar la unidad");
             Console.ReadKey();

             client.DeleteUnit(new DeleteRequest() { Id = createResponse.Id});
             var deletedGetResponse = client.GetUnit(new GetRequest() { Id = createResponse.Id });
             if (deletedGetResponse is null || 
                 deletedGetResponse.KindCase != NullableUnitDTO.KindOneofCase.Unit)
             {
                 Console.WriteLine($"Eliminación exitosa.");
             }
             //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            Console.WriteLine("==========================================================================");
            Console.WriteLine("==========================================================================");
            //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            var client1 = new AccessControlSystem.GrpcServices.Protos.User.UserClient(channel);
            Console.WriteLine("Presione una tecla para crear un usuario");
            Console.ReadKey();
            var createResponse1 = client1.CreateUser(new CreateUserRequest()
            {
               FirstName="Ronald",
               LastName="Regalado",
               Ci="01022065449"
            });

            if (createResponse is null)
            {
                Console.WriteLine("Cannot create user");
                channel.Dispose();
                return;
            }
            else
            {
                Console.WriteLine($"Creación exitosa.");
            }

            Console.WriteLine("Presione una tecla para obtener todas las unidades");
            Console.ReadKey();
            var getResponse1= client1.GetAllUsers(new Google.Protobuf.WellKnownTypes.Empty());
            if (getResponse1.Items is null)
            {
                Console.WriteLine("Cannot get users");
                channel.Dispose();
                return;
            }
            else
            {
                Console.WriteLine($"Obtención exitosa de {getResponse1.Items.Count} Usuarios");
            }

            Console.WriteLine($"Presione una tecla para obtener  con Id {createResponse1.Id}");
            Console.ReadKey();
            var getByIdResponse1 = client1.GetUser(new GetRequest() { Id = createResponse1.Id.ToString() });
            if (getByIdResponse1 is null)
            {
                Console.WriteLine("Cannot get User");
                channel.Dispose();
                return;
            }
            else
            {
                Console.WriteLine($"Obtención exitosa del usuario {getByIdResponse1.User.FirstName} {getByIdResponse1.User.LastName}");
            }

            Console.WriteLine("Presione una tecla para modificar el usuario");
            Console.ReadKey();
            createResponse1.Ci = createResponse1.Ci.ToUpper();
            client1.UpdateUser(createResponse1);

            var updatedGetResponse1 = client1.GetUser(new GetRequest() { Id = createResponse1.Id });
            if (updatedGetResponse1 is not null &&
                updatedGetResponse1.KindCase == NullableUserDTO.KindOneofCase.User &&
                updatedGetResponse1.User.Ci == createResponse1.Ci)
            {
                Console.WriteLine($"Modificación exitosa.");
            }
            
            Console.WriteLine("Presione una tecla para eliminar el usuario");
            Console.ReadKey();

            client1.DeleteUser(new DeleteRequest() { Id = createResponse1.Id });
            var deletedGetResponse1 = client1.GetUser(new GetRequest() { Id = createResponse1.Id });
            if (deletedGetResponse1 is null ||
                deletedGetResponse1.KindCase != NullableUserDTO.KindOneofCase.User)
            {
                Console.WriteLine($"Eliminación exitosa.");
            }
            
            /*
            //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            Console.WriteLine("==========================================================================");
            Console.WriteLine("==========================================================================");
            //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            var client2 = new AccessControlSystem.GrpcServices.Protos.UserSession.UserSessionClient(channel);
            Console.WriteLine("Presione una tecla para crear un sesion");
            Console.ReadKey();

            createResponse.Id= Guid.NewGuid().ToString();
            createResponse1.Id= Guid.NewGuid().ToString();
            var createResponse2 = client2.CreateUserSession(new CreateUserSessionRequest()
            {
                User =createResponse1,
                BusyUnit=createResponse
                
            });

            if (createResponse2 is null)
            {
                Console.WriteLine("Cannot create UserSession");
                channel.Dispose();
                return;
            }
            else
            {
                Console.WriteLine($"Creación exitosa.");
            }

            Console.WriteLine("Presione una tecla para obtener todas los horarios");
            Console.ReadKey();
            var getResponse2 = client2.GetAllUserSessions(new Google.Protobuf.WellKnownTypes.Empty());
            if (getResponse2.Items is null)
            {
                Console.WriteLine("Cannot get UserSessions");
                channel.Dispose();
                return;
            }
            else
            {
                Console.WriteLine($"Obtención exitosa de {getResponse2.Items.Count} Horarios");
            }

            Console.WriteLine($"Presione una tecla para obtener un horario con Id {createResponse2.Id}");
            Console.ReadKey();
            var getByIdResponse2 = client2.GetUserSession(new GetRequest() { Id = createResponse2.Id.ToString() });
            if (getByIdResponse2 is null)
            {
                Console.WriteLine("Cannot get UserSession");
                channel.Dispose();
                return;
            }
            else
            {
                Console.WriteLine($"Obtención exitosa del sesion {getByIdResponse2.UserSession.Id} perteneciente a {getByIdResponse2.UserSession.UserId} {getByIdResponse2.UserSession.UnitId}");
            }

            Console.WriteLine("Presione una tecla para modificar el sesion");
            Console.ReadKey();
            createResponse2.EndTime =Timestamp.FromDateTime(DateTime.UtcNow);
            client2.UpdateUserSession(createResponse2);

            var updatedGetResponse2 = client2.GetUserSession(new GetRequest() { Id = createResponse2.Id });
            if (updatedGetResponse2 is not null &&
                updatedGetResponse2.KindCase == NullableUserSessionDTO.KindOneofCase.UserSession &&
                updatedGetResponse2.UserSession.EndTime == createResponse2.EndTime)
            {
                Console.WriteLine($"Modificación exitosa.");
            }

            Console.WriteLine("Presione una tecla para eliminar la session");
            Console.ReadKey();

            client2.DeleteUserSession(new DeleteRequest() { Id = createResponse2.Id });
            var deletedGetResponse2 = client2.GetUserSession(new GetRequest() { Id = createResponse2.Id });
            if (deletedGetResponse2 is null ||
                deletedGetResponse2.KindCase != NullableUserSessionDTO.KindOneofCase.UserSession)
            {
                Console.WriteLine($"Eliminación exitosa.");
            }*/
            
            //===========================================================================
            /*
            Console.WriteLine("Presione una tecla para eliminar el usuario");
            Console.ReadKey();
            
            client1.DeleteUser(new DeleteRequest() { Id = createResponse1.Id });
            var deletedGetResponse1 = client1.GetUser(new GetRequest() { Id = createResponse1.Id });
            if (deletedGetResponse1 is null ||
                deletedGetResponse1.KindCase != NullableUserDTO.KindOneofCase.User)
            {
                Console.WriteLine($"Eliminación exitosa.");
            }
            //=============================================================================

            Console.WriteLine("Presione una tecla para eliminar la unidad");
            Console.ReadKey();

            client.DeleteUnit(new DeleteRequest() { Id = createResponse.Id });
            var deletedGetResponse = client.GetUnit(new GetRequest() { Id = createResponse.Id });
            if (deletedGetResponse is null ||
                deletedGetResponse.KindCase != NullableUnitDTO.KindOneofCase.Unit)
            {
                Console.WriteLine($"Eliminación exitosa.");
            }*/
            

            channel.Dispose();


        }
    }
}

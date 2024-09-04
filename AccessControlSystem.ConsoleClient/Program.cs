using AccessControlSystem.Domain.Entities.Units;
using AccessControlSystem.GrpcServices.Protos;
using Grpc.Net.Client;
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


             channel.Dispose();


        }
    }
}

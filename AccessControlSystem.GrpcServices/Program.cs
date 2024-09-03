using AccessControlSystem.GrpcServices.Services;
using AccessControlSystem.DataAccess.Repositories;
using AccessControlSystem.Contracts.Users;
using AccessControlSystem.DataAccess;
using AccessControlSystem.DataAccess.Repositories.Users;
using AccessControlSystem.Contracts;
using AccessControlSystem.DataAccess.Contexts;
using AccessControlSystem.DataAccess.Repositories.Units;
using AccessControlSystem.Contracts.Units;
using AccessControlSystem.DataAccess.Repositories.UserSchedules;
using AccessControlSystem.Contracts.UserSchedules;
using AccessControlSystem.DataAccess.Repositories.UserSessions;
using AccessControlSystem.Contracts.UserSessions;
using System.Reflection.Metadata;


namespace AccessControlSystem.GrpcServices
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Additional configuration is required to successfully run gRPC on macOS.
            // For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

            // Add services to the container.
            builder.Services.AddGrpc();
            builder.Services.AddAutoMapper(typeof(Program).Assembly);
            builder.Services.AddMediatR(new MediatRServiceConfiguration()
            {
                AutoRegisterRequestProcessors = true,
            }
            .RegisterServicesFromAssemblies(typeof(AssemblyReference).Assembly));


            builder.Services.AddSingleton("Data Source = CarDealerDB.sqlite");
            builder.Services.AddScoped<ApplicationContext>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IUnitRepository, UnitRepository>();
            builder.Services.AddScoped<IUserScheduleRepository, UserScheduleRepository>();
            builder.Services.AddScoped<IUserSessionRepository, UserSessionRepository>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.MapGrpcService<GreeterService>();
            app.MapGrpcService<UnitService>();
            app.MapGrpcService<UserService>();
            app.MapGrpcService<UserScheduleService>();
            app.MapGrpcService<UserSessionService>();

            app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

            app.Run();
        }
    }
}
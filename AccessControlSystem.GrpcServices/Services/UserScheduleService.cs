using AccessControlSystem.Contracts.UserSchedules;
using AccessControlSystem.Contracts;
using AccessControlSystem.GrpcServices;
using AccessControlSystem.GrpcServices.Protos;
using AccessControlSystem.Application.UserSchedules.Commands.CreateUserSchedule;
using AccessControlSystem.Application.UserSchedules.Commands.DeleteUserSchedule;
using AccessControlSystem.Application.UserSchedules.Commands.UpdateUserSchedule;
using AccessControlSystem.Application.UserSchedules.Queries.GetAllUserSchedules;
using AccessControlSystem.Application.UserSchedules.Queries.GetUserScheduleById;
using AccessControlSystem.Domain.Entities.Users;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using MediatR;
using AccessControlSystem.Application.UserSchedules.Commands.CreateUserSchedule;
using AutoMapper;


namespace AccessControlSystem.GrpcServices.Services
{
    public class UserScheduleService: UserSchedule.UserScheduleBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public UserScheduleService(IMediator mediator,IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        /*TODO: ver en que afecta el cambio de dato de google.protobuf.Timestamp(DateTime) 
         * por int64 para poder ser la llave del map(dictionary)*/
        public override Task<UserScheduleDTO> CreateUserSchedule(CreateUserScheduleRequest request, ServerCallContext context)
        {
            var command = new CreateUserScheduleCommand(_mapper.Map<Domain.Entities.Users.User>(request.User));
            var result = _mediator.Send(command).Result;
            return Task.FromResult(_mapper.Map<UserScheduleDTO>(result));
        }
        public override Task<NullableUserScheduleDTO> GetUserSchedule(GetRequest request, ServerCallContext context)
        {
            var query = new GetUserScheduleByIdQuery(new Guid(request.Id));
            var result = _mediator.Send(query).Result;

            if (result is null)
                return Task.FromResult(new NullableUserScheduleDTO() { Null = NullValue.NullValue });
            return Task.FromResult(new NullableUserScheduleDTO() { UserSchedule = _mapper.Map<UserScheduleDTO>(result) });
        }
        public override Task<UserSchedules> GetAllUserSchedules(Empty request, ServerCallContext context)
        {
            var query = new GetAllUserSchedulesQuery();
            var result = _mediator.Send(query).Result;

            // Convirtiendo de lista de horarios al mensaje de lista de DTOs de horarios.
            var userSchedulesDTOs = new UserSchedules();
            userSchedulesDTOs.Items.AddRange(result.Select(m => _mapper.Map<UserScheduleDTO>(m)));

            return Task.FromResult(userSchedulesDTOs);

        }
        public override Task<Empty> UpdateUserSchedule(UserScheduleDTO request, ServerCallContext context)
        {
            var command = new UpdateUserScheduleCommand(_mapper.Map<Domain.Entities.UserSchedules.UserSchedule>(request));

            _mediator.Send(command);

            return Task.FromResult(new Empty());
        }
        public override Task<Empty> DeleteUserSchedule(DeleteRequest request, ServerCallContext context)
        {
            var command = new DeleteUserScheduleCommand(new Guid(request.Id));

            _mediator.Send(command);

            return Task.FromResult(new Empty());
        }
    }
}

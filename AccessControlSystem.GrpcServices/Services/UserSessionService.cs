using AccessControlSystem.Contracts.UserSessions;
using AccessControlSystem.Contracts;
using AccessControlSystem.GrpcServices;
using AccessControlSystem.GrpcServices.Protos;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using AutoMapper;
using MediatR;
using AccessControlSystem.Application.UserSessions.Commands.CreateUserSession;
using AccessControlSystem.Application.Users.Queries.GetUserById;
using AccessControlSystem.Application.UserSessions.Queries.GetUserSessionById;
using AccessControlSystem.Application.Users.Queries.GetAllUsers;
using AccessControlSystem.Application.UserSessions.Queries.GetAllUserSessions;
using AccessControlSystem.Application.Users.Commands.UpdateUser;
using AccessControlSystem.Application.UserSessions.Commands.UpdateUserSession;

namespace AccessControlSystem.GrpcServices.Services
{
    public class UserSessionService:UserSession.UserSessionBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public UserSessionService(IMediator mediator, IMapper mapper)
        {
            _mapper = mapper;
            _mediator = mediator;

        }
        public override Task<UserSessionDTO> CreateUserSession(CreateUserSessionRequest request, ServerCallContext context)
        {
            var command = new CreateUserSessionCommand(
                _mapper.Map<Domain.Entities.Users.User>(request.User),
                _mapper.Map<Domain.Entities.Units.Unit>(request.BusyUnit)
                );
            var result = _mediator.Send(command).Result;
            return Task.FromResult(_mapper.Map<UserSessionDTO>(result));
        }
        public override Task<NullableUserSessionDTO> GetUserSession(GetRequest request, ServerCallContext context)
        {
            var query = new GetUserSessionByIdQuery(new Guid(request.Id));
            var result = _mediator.Send(query).Result;

            if (result is null)
                return Task.FromResult(new NullableUserSessionDTO() { Null = NullValue.NullValue });
            return Task.FromResult(new NullableUserSessionDTO() { UserSession = _mapper.Map<UserSessionDTO>(result) });
        }
        public override Task<UserSessions> GetAllUserSessions(Empty request, ServerCallContext context)
        {
            var query = new GetAllUserSessionsQuery();
            var result = _mediator.Send(query).Result;

            // Convirtiendo de lista de horarios al mensaje de lista de DTOs de horarios.
            var UserSessionDTOs = new UserSessions();
            UserSessionDTOs.Items.AddRange(result.Select(m => _mapper.Map<UserSessionDTO>(m)));

            return Task.FromResult(UserSessionDTOs);
        }
        public override Task<Empty> UpdateUserSession(UserSessionDTO request, ServerCallContext context)
        {
            var command = new UpdateUserSessionCommand(_mapper.Map<Domain.Entities.UserSessions.UserSession>(request));

            _mediator.Send(command);

            return Task.FromResult(new Empty());
        }
        public override Task<Empty> DeleteUserSession(DeleteRequest request, ServerCallContext context)
        {
            var command = new UpdateUserSessionCommand(_mapper.Map<Domain.Entities.UserSessions.UserSession>(request));

            _mediator.Send(command);

            return Task.FromResult(new Empty());
        }
    }
}

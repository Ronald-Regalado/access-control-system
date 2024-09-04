using AccessControlSystem.Contracts.Users;
using AccessControlSystem.Contracts;
using AccessControlSystem.GrpcServices;
using AccessControlSystem.GrpcServices.Protos;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using AutoMapper;
using MediatR;
using AccessControlSystem.Application.Users.Commands.CreateUser;
using AccessControlSystem.Application.Users.Queries.GetUserById;
using AccessControlSystem.Application.Users.Queries.GetAllUsers;
using AccessControlSystem.Application.Users.Commands.UpdateUser;


namespace AccessControlSystem.GrpcServices.Services
{
    public class UserService : User.UserBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public UserService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;

        }
        public override Task<UserDTO> CreateUser(CreateUserRequest request, ServerCallContext context)
        {
            var command = new CreateUserCommand(request.FirstName,request.LastName,request.Ci);
            var result = _mediator.Send(command).Result;
            return Task.FromResult(_mapper.Map<UserDTO>(result));
        }

        public override Task<NullableUserDTO> GetUser(GetRequest request, ServerCallContext context)
        {
            var query = new GetUserByIdQuery(new Guid(request.Id));
            var result = _mediator.Send(query).Result;

            if (result is null)
                return Task.FromResult(new NullableUserDTO() { Null = NullValue.NullValue });
            return Task.FromResult(new NullableUserDTO() { User = _mapper.Map<UserDTO>(result) });
        }

        public override Task<Users> GetAllUsers(Empty request, ServerCallContext context)
        {
            var query = new GetAllUsersQuery();
            var result = _mediator.Send(query).Result;

            // Convirtiendo de lista de horarios al mensaje de lista de DTOs de horarios.
            var UsersDTOs = new Users();
            UsersDTOs.Items.AddRange(result.Select(m => _mapper.Map<UserDTO>(m)));

            return Task.FromResult(UsersDTOs);
        }

        public override Task<Empty> UpdateUser(UserDTO request, ServerCallContext context)
        {
            var command = new UpdateUserCommand(_mapper.Map<Domain.Entities.Users.User>(request));

            _mediator.Send(command);

            return Task.FromResult(new Empty());
        }

        public override Task<Empty> DeleteUser(DeleteRequest request, ServerCallContext context)
        {
            var command = new UpdateUserCommand(_mapper.Map<Domain.Entities.Users.User>(request));

            _mediator.Send(command);

            return Task.FromResult(new Empty());
        }
    }
}

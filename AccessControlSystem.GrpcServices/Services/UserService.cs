using AccessControlSystem.GrpcServices;
using AccessControlSystem.GrpcServices.Protos;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace AccessControlSystem.GrpcServices.Services
{
    public class UserService : User.UserBase
    {
        public override Task<UserDTO> CreateUser(CreateUserRequest request, ServerCallContext context)
        {
            return base.CreateUser(request, context);
        }

        public override Task<NullableUserDTO> GetUser(GetRequest request, ServerCallContext context)
        {
            return base.GetUser(request, context);
        }

        public override Task<Users> GetAllUsers(Empty request, ServerCallContext context)
        {
            return base.GetAllUsers(request, context);
        }

        public override Task<Empty> UpdateUser(UserDTO request, ServerCallContext context)
        {
            return base.UpdateUser(request, context);
        }

        public override Task<Empty> DeleteUser(DeleteRequest request, ServerCallContext context)
        {
            return base.DeleteUser(request, context);
        }
    }
}

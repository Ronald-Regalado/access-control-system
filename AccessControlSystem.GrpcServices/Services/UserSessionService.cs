using AccessControlSystem.GrpcServices;
using AccessControlSystem.GrpcServices.Protos;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace AccessControlSystem.GrpcServices.Services
{
    public class UserSessionService:UserSession.UserSessionBase
    {
        public override Task<UserSessionDTO> CreateUserSession(CreateUserSessionRequest request, ServerCallContext context)
        {
            return base.CreateUserSession(request, context);
        }
        public override Task<NullableUserSessionDTO> GetUserSession(GetRequest request, ServerCallContext context)
        {
            return base.GetUserSession(request, context);
        }
        public override Task<UserSessions> GetAllUserSessions(Empty request, ServerCallContext context)
        {
            return base.GetAllUserSessions(request, context);
        }
        public override Task<Empty> UpdateUserSession(UserSessionDTO request, ServerCallContext context)
        {
            return base.UpdateUserSession(request, context);
        }
        public override Task<Empty> DeleteUserSession(DeleteRequest request, ServerCallContext context)
        {
            return base.DeleteUserSession(request, context);
        }
    }
}

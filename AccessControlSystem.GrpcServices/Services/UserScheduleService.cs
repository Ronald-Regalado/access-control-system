using AccessControlSystem.Contracts.UserSchedules;
using AccessControlSystem.Contracts;
using AccessControlSystem.GrpcServices;
using AccessControlSystem.GrpcServices.Protos;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;


namespace AccessControlSystem.GrpcServices.Services
{
    public class UserScheduleService: UserSchedule.UserScheduleBase
    {
        private readonly IUserScheduleRepository _userScheduleRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserScheduleService(IUserScheduleRepository userScheduleRepository, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _userScheduleRepository = userScheduleRepository;
        }

        /*TODO: ver en que afecta el cambio de dato de google.protobuf.Timestamp(DateTime) 
         * por int64 para poder ser la llave del map(dictionary)*/
        public override Task<UserScheduleDTO> CreateUserSchedule(CreateUserScheduleRequest request, ServerCallContext context)
        {
            return base.CreateUserSchedule(request, context);
        }
        public override Task<NullableUserScheduleDTO> GetUserSchedule(GetRequest request, ServerCallContext context)
        {
            return base.GetUserSchedule(request, context);
        }
        public override Task<UserSchedules> GetAllUserSchedules(Empty request, ServerCallContext context)
        {
            return base.GetAllUserSchedules(request, context);
        }
        public override Task<Empty> UpdateUserSchedule(UserScheduleDTO request, ServerCallContext context)
        {
            return base.UpdateUserSchedule(request, context);
        }
        public override Task<Empty> DeleteUserSchedule(DeleteRequest request, ServerCallContext context)
        {
            return base.DeleteUserSchedule(request, context);
        }
    }
}

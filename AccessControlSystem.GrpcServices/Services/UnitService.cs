using AccessControlSystem.GrpcServices;
using AccessControlSystem.GrpcServices.Protos;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace AccessControlSystem.GrpcServices.Services
{
    public class UnitService : Unit.UnitBase
    {
        public override Task<UnitDTO> CreateUnit(CreateUnitRequest request, ServerCallContext context)
        {
            return base.CreateUnit(request, context);
        }

        public override Task<NullableUnitDTO> GetUnit(GetRequest request, ServerCallContext context)
        {
            return base.GetUnit(request, context);
        }

        public override Task<Units> GetAllUnits(Empty request, ServerCallContext context)
        {
            return base.GetAllUnits(request, context);
        }

        public override Task<Empty> UpdateUnit(UnitDTO request, ServerCallContext context)
        {
            return base.UpdateUnit(request, context);
        }

        public override Task<Empty> DeleteUnit(DeleteRequest request, ServerCallContext context)
        {
            return base.DeleteUnit(request, context);
        }

    }
}

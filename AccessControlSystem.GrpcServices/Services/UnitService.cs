using AccessControlSystem.Application.Units.Commands.CreateUnit;
using AccessControlSystem.Application.Units.Queries.GetUnitById;
using AccessControlSystem.Application.Units.Queries.GetAllUnits;
using AccessControlSystem.Contracts;
using AccessControlSystem.Contracts.Units;
using AccessControlSystem.GrpcServices;
using AccessControlSystem.GrpcServices.Protos;
using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using MediatR;
using AccessControlSystem.Application.Units.Commands.UpdateUnit;

namespace AccessControlSystem.GrpcServices.Services
{
    public class UnitService : Protos.Unit.UnitBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public UnitService(IMediator mediator,IMapper mapper)
        {
            _mapper = mapper;
            _mediator = mediator;
            
        }
        public override Task<UnitDTO> CreateUnit(CreateUnitRequest request, ServerCallContext context)
        {
            var command = new CreateUnitCommand(request.Maker,request.Code);
            var result = _mediator.Send(command).Result;
            return Task.FromResult(_mapper.Map<UnitDTO>(result));
        }

        public override Task<NullableUnitDTO> GetUnit(GetRequest request, ServerCallContext context)
        {
            var query = new GetUnitByIdQuery(new Guid(request.Id));
            var result = _mediator.Send(query).Result;

            if (result is null)
                return Task.FromResult(new NullableUnitDTO() { Null = NullValue.NullValue });
            return Task.FromResult(new NullableUnitDTO() { Unit = _mapper.Map<UnitDTO>(result) });
        }

        public override Task<Units> GetAllUnits(Empty request, ServerCallContext context)
        {
            var query = new GetAllUnitsQuery();
            var result = _mediator.Send(query).Result;

            // Convirtiendo de lista de horarios al mensaje de lista de DTOs de horarios.
            var UnitsDTOs = new Units();
            UnitsDTOs.Items.AddRange(result.Select(m => _mapper.Map<UnitDTO>(m)));

            return Task.FromResult(UnitsDTOs);
        }

        public override Task<Empty> UpdateUnit(UnitDTO request, ServerCallContext context)
        {
            var command = new UpdateUnitCommand(_mapper.Map<Domain.Entities.Units.Unit>(request));

            _mediator.Send(command);

            return Task.FromResult(new Empty());
        }

        public override Task<Empty> DeleteUnit(DeleteRequest request, ServerCallContext context)
        {
            var command = new UpdateUnitCommand(_mapper.Map<Domain.Entities.Units.Unit>(request));

            _mediator.Send(command);

            return Task.FromResult(new Empty());
        }

    }
}

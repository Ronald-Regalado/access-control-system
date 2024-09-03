using AccessControlSystem.Application.Abstract;
using AccessControlSystem.Contracts.Units;
using AccessControlSystem.Domain.Entities.Units;

namespace AccessControlSystem.Application.Units.Queries.GetUnitById
{

    public class GetUnitByIdQueryHandler : IQueryHandler<GetUnitByIdQuery,Unit>
    {
        private readonly IUnitRepository _unitRepository;
        public GetUnitByIdQueryHandler(IUnitRepository unitRepository)
        {
            _unitRepository = unitRepository;
        }

        public Task<Unit?> Handle(GetUnitByIdQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_unitRepository.GetUnitById(request.Id));
        }

    }
}


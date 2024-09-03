using AccessControlSystem.Application.Abstract;
using AccessControlSystem.Contracts;
using AccessControlSystem.Contracts.Units;
using AccessControlSystem.Domain.Entities.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessControlSystem.Application.Units.Queries.GetAllUnits
{
    public class GetAllUnitsQueryHandler: IQueryHandler<GetAllUnitsQuery,IEnumerable<Unit>>
    {
        private readonly IUnitRepository _unitRepository;
        private readonly IUnitOfWork _unitOfWork;

        public GetAllUnitsQueryHandler(IUnitRepository unitRepository, IUnitOfWork unitOfWork)
        {
            _unitRepository = unitRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<IEnumerable<Unit>> Handle(GetAllUnitsQuery request,CancellationToken cancellationToken)
        {
            IEnumerable<Unit> units= _unitRepository.GetAllUnits();
            return Task.FromResult(units);
        }
    }
}

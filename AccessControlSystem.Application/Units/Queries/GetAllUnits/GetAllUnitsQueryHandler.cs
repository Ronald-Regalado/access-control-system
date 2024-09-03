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
    public class GetAllUnitsQueryHandler
        : IQueryHandler<GetAllUnitsQuery,IEnumerable<Unit>>
    {
        private readonly IUnitRepository _unitRepository;
       

        public GetAllUnitsQueryHandler(IUnitRepository unitRepository)
        {
            _unitRepository = unitRepository;
          
        }

        public Task<IEnumerable<Unit>> Handle(GetAllUnitsQuery request,CancellationToken cancellationToken) 
        {
            IEnumerable<Unit> units = _unitRepository.GetAllUnits();
            return Task.FromResult(units);
            
        }
    }
}

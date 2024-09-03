using AccessControlSystem.Application.Abstract;
using AccessControlSystem.Contracts;
using AccessControlSystem.Contracts.Units;
using AccessControlSystem.Domain.Entities.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessControlSystem.Application.Units.Commands.CreateUnit
{
    public class CreateUnitCommandHandler
        : ICommandHandler<CreateUnitCommand, Unit>
    {
        private readonly IUnitRepository _unitRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateUnitCommandHandler(
            IUnitRepository UnitRepository,
            IUnitOfWork unitOfWork)
        {
            _unitRepository = UnitRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<Unit> Handle(CreateUnitCommand request, CancellationToken cancellationToken)
        {
            Unit result = new Unit(
                request.maker,
                request.code,
                Guid.NewGuid()
                );

            _unitRepository.AddUnit(result);
            _unitOfWork.SaveChanges();

            return Task.FromResult(result);
        }
    }
}

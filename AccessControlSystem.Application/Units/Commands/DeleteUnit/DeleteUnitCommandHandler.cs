using AccessControlSystem.Application.Abstract;
using AccessControlSystem.Contracts;
using AccessControlSystem.Contracts.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessControlSystem.Application.Units.Commands.DeleteUnit
{
    public class DeleteUnitCommandHandler: ICommandHandler<DeleteUnitCommand>
    {
        private IUnitRepository _unitRepository;
        private IUnitOfWork _unitOfWork;

        public DeleteUnitCommandHandler(
           IUnitRepository unitRepository,
           IUnitOfWork unitOfWork)
        {
            _unitRepository = unitRepository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle(DeleteUnitCommand request, CancellationToken cancellationToken)
        {
            var unitToDelete = _unitRepository.GetUnitById(request.id);
            if (unitToDelete is null)
                return Task.CompletedTask;
            _unitRepository.DeleteUnit(unitToDelete);
            _unitOfWork.SaveChanges();

            return Task.CompletedTask;
        }
    }
}

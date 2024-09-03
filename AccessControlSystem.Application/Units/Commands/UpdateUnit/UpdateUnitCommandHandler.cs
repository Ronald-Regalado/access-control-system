using AccessControlSystem.Application.Abstract;
using AccessControlSystem.Contracts;
using AccessControlSystem.Contracts.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessControlSystem.Application.Units.Commands.UpdateUnit
{
    public class UpdateUnitCommandHandler:ICommandHandler<UpdateUnitCommand>
    {
        private readonly IUnitRepository _unitRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateUnitCommandHandler(
            IUnitRepository unitRepository,
            IUnitOfWork unitOfWork)
        {
            _unitRepository = unitRepository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle(UpdateUnitCommand request, CancellationToken cancellationToken)
        {
            _unitRepository.UpdateUnit(request.unit);
            _unitOfWork.SaveChanges();
            return Task.CompletedTask;
        }
    }
}

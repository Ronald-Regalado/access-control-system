using AccessControlSystem.Application.Abstract;
using AccessControlSystem.Contracts.UserSchedules;
using AccessControlSystem.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessControlSystem.Application.UserSchedules.Commands.UpdateUserSchedule
{
    public class UpdateUserScheduleCommandHandler: ICommand
    {
        private readonly IUserScheduleRepository _userScheduleRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateUserScheduleCommandHandler(IUserScheduleRepository userScheduleRepository, IUnitOfWork unitOfWork)
        {
            _userScheduleRepository = userScheduleRepository;
            _unitOfWork = unitOfWork;
        }
        public Task Handle(UpdateUserScheduleCommand request,CancellationToken cancellationToken) 
        {
            _userScheduleRepository.UpdateUserSchedule(request.userSchedule);
            _unitOfWork.SaveChanges();
            return Task.CompletedTask;
        }
    }
}

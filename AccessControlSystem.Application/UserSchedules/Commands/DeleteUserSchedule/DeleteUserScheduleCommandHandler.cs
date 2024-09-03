using AccessControlSystem.Application.Abstract;
using AccessControlSystem.Contracts.UserSchedules;
using AccessControlSystem.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessControlSystem.Application.UserSchedules.Commands.DeleteUserSchedule
{
    public class DeleteUserScheduleCommandHandler: ICommand
    {
        private readonly IUserScheduleRepository _userScheduleRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteUserScheduleCommandHandler(IUserScheduleRepository userScheduleRepository, IUnitOfWork unitOfWork)
        {
            _userScheduleRepository = userScheduleRepository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle(DeleteUserScheduleCommand request, CancellationToken cancellationToken)
        {
            var userScheduleToDelete=_userScheduleRepository.GetUserScheduleById(request.id);
            if (userScheduleToDelete is null)
                return Task.CompletedTask;
            _userScheduleRepository.DeleteUserSchedule(userScheduleToDelete);
            _unitOfWork.SaveChanges();
            return Task.CompletedTask;
        }
    }
}

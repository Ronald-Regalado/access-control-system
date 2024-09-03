using AccessControlSystem.Application.Abstract;
using AccessControlSystem.Contracts;
using AccessControlSystem.Contracts.UserSchedules;
using AccessControlSystem.Domain.Entities.UserSchedules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessControlSystem.Application.UserSchedules.Commands.CreateUserSchedule
{
    public class CreateUserScheduleCommandHandler: ICommand<UserSchedule>
    {
        private readonly IUserScheduleRepository _userScheduleRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateUserScheduleCommandHandler(IUserScheduleRepository userScheduleRepository, IUnitOfWork unitOfWork)
        {
            _userScheduleRepository = userScheduleRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<UserSchedule> Handle( CreateUserScheduleCommand request,CancellationToken cancellationToken)
        {
            var result = new UserSchedule(
                request.user,
                Guid.NewGuid());
            _userScheduleRepository.AddUserSchedule(result);
             _unitOfWork.SaveChanges();

            return Task.FromResult(result);
        }
    }
}

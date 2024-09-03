using AccessControlSystem.Application.Abstract;
using AccessControlSystem.Contracts.UserSessions;
using AccessControlSystem.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessControlSystem.Application.UserSessions.Commands.UpdateUserSession
{
    public class UpdateUserSessionCommandHandler:ICommand<UpdateUserSessionCommand>
    {
        private readonly IUserSessionRepository _userSessionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateUserSessionCommandHandler(IUserSessionRepository userSessionRepository, IUnitOfWork unitOfWork)
        {
            _userSessionRepository = userSessionRepository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle(UpdateUserSessionCommand request,CancellationToken cancellationToken)
        {
            _userSessionRepository.UpdateUserSession(request.userSession);
            _unitOfWork.SaveChanges();
            return Task.CompletedTask;
        }
    }

}

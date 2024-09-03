using AccessControlSystem.Application.Abstract;
using AccessControlSystem.Contracts.UserSessions;
using AccessControlSystem.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessControlSystem.Application.UserSessions.Commands.DeleteUserSession
{
    public class DeleteUserSessionCommandHandler:ICommand<DeleteUserSessionCommand>
    {
        private readonly IUserSessionRepository _userSessionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteUserSessionCommandHandler(IUserSessionRepository userSessionRepository, IUnitOfWork unitOfWork)
        {
            _userSessionRepository = userSessionRepository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle(DeleteUserSessionCommand request,CancellationToken cancellationToken)
        {
            var userSessionToDelete = _userSessionRepository.GetUserSessionById(request.id);
            if (userSessionToDelete is null)
                return Task.CompletedTask;
            _userSessionRepository.DeleteUserSession(userSessionToDelete);
            _unitOfWork.SaveChanges();
            return Task.CompletedTask;
        }

    }
}

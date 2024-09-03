using AccessControlSystem.Application.Abstract;
using AccessControlSystem.Contracts;
using AccessControlSystem.Contracts.UserSessions;
using AccessControlSystem.Domain.Entities.UserSessions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessControlSystem.Application.UserSessions.Commands.CreateUserSession
{
    public class CreateUserSessionCommandHandler
        : ICommandHandler<CreateUserSessionCommand,UserSession>
    {
        private readonly IUserSessionRepository _userSessionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateUserSessionCommandHandler(IUserSessionRepository userSessionRepository, IUnitOfWork unitOfWork)
        {
            _userSessionRepository = userSessionRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<UserSession> Handle(CreateUserSessionCommand request,CancellationToken cancellationToken)
        {
            var newUserSession = new UserSession(
                request.user, 
                request.unit,
                Guid.NewGuid()
                );
             _userSessionRepository.AddUserSession( newUserSession );
            _unitOfWork.SaveChanges();
            return Task.FromResult( newUserSession );
        }
    }
}

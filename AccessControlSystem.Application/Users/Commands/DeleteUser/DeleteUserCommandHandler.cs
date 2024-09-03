using AccessControlSystem.Application.Abstract;
using AccessControlSystem.Application.Units.Commands.DeleteUnit;
using AccessControlSystem.Contracts.Units;
using AccessControlSystem.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccessControlSystem.Contracts.Users;

namespace AccessControlSystem.Application.Users.Commands.DeleteUser
{
    public class DeleteUserCommandHandler:ICommandHandler<DeleteUserCommand>
    {
        private IUserRepository _userRepository;
        private IUnitOfWork _unitOfWork;

        public DeleteUserCommandHandler(
           IUserRepository userRepository,
           IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var userToDelete = _userRepository.GetUserById(request.id);
            if (userToDelete is null)
                return Task.CompletedTask;
            _userRepository.DeleteUser(userToDelete);
            _unitOfWork.SaveChanges();

            return Task.CompletedTask;
        }
    }
}

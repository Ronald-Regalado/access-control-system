using AccessControlSystem.Application.Users.Commands.CreateUser;
using AccessControlSystem.Contracts.Users;
using AccessControlSystem.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccessControlSystem.Application.Abstract;
using AccessControlSystem.Domain.Entities.Users;

namespace AccessControlSystem.Application.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler
       : ICommandHandler<CreateUserCommand, User>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateUserCommandHandler(
            IUserRepository userRepository,
            IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork= unitOfWork;
        }

        public Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            User result = new User(
                request.firstName,
                request.lastName,
                request.ci,
                Guid.NewGuid());

            _userRepository.AddUser(result);
            _unitOfWork.SaveChanges();

            return Task.FromResult(result);
        }
    }
}

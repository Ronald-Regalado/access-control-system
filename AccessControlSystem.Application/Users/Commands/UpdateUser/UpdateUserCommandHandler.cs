using AccessControlSystem.Application.Abstract;
using AccessControlSystem.Contracts;
using AccessControlSystem.Contracts.Users;

namespace AccessControlSystem.Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : ICommandHandler<UpdateUserCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            _userRepository.UpdateUser(request.user);
            _unitOfWork.SaveChanges();
            return Task.CompletedTask;
        }
    }
}

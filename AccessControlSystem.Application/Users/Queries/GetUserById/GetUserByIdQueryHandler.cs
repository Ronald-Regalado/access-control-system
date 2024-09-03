using AccessControlSystem.Application.Abstract;
using AccessControlSystem.Contracts.Users;
using AccessControlSystem.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessControlSystem.Application.Users.Queries.GetUserById
{
    public class GetUserByIdQueryHandler : IQueryHandler<GetUserByIdQuery,User?>
    {
        private IUserRepository _userRepository;

        public GetUserByIdQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<User?> Handle(GetUserByIdQuery request,CancellationToken cancellationToken)
        {
            var result=_userRepository.GetUserById(request.id);
            return Task.FromResult(result);
        }
    }
}

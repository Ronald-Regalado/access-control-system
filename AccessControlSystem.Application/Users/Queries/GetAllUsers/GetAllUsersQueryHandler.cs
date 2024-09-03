using AccessControlSystem.Application.Abstract;
using AccessControlSystem.Contracts.Users;
using AccessControlSystem.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessControlSystem.Application.Users.Queries.GetAllUsers
{
    public class GetAllUsersQueryHandler 
        : IQueryHandler<GetAllUsersQuery,IEnumerable<User>>
    {
        private readonly IUserRepository _userRepository;

        public GetAllUsersQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<IEnumerable<User>> Handle(GetAllUsersQuery request,CancellationToken cancellationToken) 
        {
            IEnumerable<User> users = _userRepository.GetAllUsers();
            return Task.FromResult(users);
        }
    }
}

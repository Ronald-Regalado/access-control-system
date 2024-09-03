using AccessControlSystem.Application.Abstract;
using AccessControlSystem.Contracts.UserSessions;
using AccessControlSystem.Domain.Entities.UserSessions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessControlSystem.Application.UserSessions.Queries.GetAllUserSessions
{
    public class GetAllUserSessionsQueryHandler
        : IQueryHandler<GetAllUserSessionsQuery,IEnumerable<UserSession>>
    {
        private readonly IUserSessionRepository _userSessionRepository;

        public GetAllUserSessionsQueryHandler(IUserSessionRepository userSessionRepository)
        {
            _userSessionRepository = userSessionRepository;
        }

        public Task<IEnumerable<UserSession>> Handle(GetAllUserSessionsQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<UserSession> userSessions = _userSessionRepository.GetAllUserSessions();
            return Task.FromResult(userSessions);
        }
    }
}

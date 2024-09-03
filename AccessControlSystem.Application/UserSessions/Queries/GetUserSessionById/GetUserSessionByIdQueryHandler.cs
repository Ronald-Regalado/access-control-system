using AccessControlSystem.Application.Abstract;
using AccessControlSystem.Contracts.UserSessions;
using AccessControlSystem.Domain.Entities.UserSessions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessControlSystem.Application.UserSessions.Queries.GetUserSessionById
{
    public class GetUserSessionByIdQueryHandler: IQueryHandler<GetUserSessionByIdQuery,UserSession>
    {
       private readonly IUserSessionRepository _userSessionRepository;

        public GetUserSessionByIdQueryHandler(IUserSessionRepository userSessionRepository)
        {
            _userSessionRepository = userSessionRepository;
        }
        public Task<UserSession> Handle(GetUserSessionByIdQuery request, CancellationToken cancellationToken)
        {
            var result = _userSessionRepository.GetUserSessionById(request.id);
            return Task.FromResult(result);
        }
    }
}

using AccessControlSystem.Application.Abstract;
using AccessControlSystem.Application.UserSchedules.Queries.GetUserScheduleById;
using AccessControlSystem.Contracts.UserSchedules;
using AccessControlSystem.Contracts;
using AccessControlSystem.Domain.Entities.UserSchedules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessControlSystem.Application.UserSchedules.Queries.GetUserScheduleById
{
    public class GetUserScheduleByIdQueryHandler:IQueryHandler<GetUserScheduleByIdQuery,UserSchedule>
    {
        private readonly IUserScheduleRepository _userScheduleRepository;

        public GetUserScheduleByIdQueryHandler(IUserScheduleRepository userScheduleRepository)
        {
            _userScheduleRepository = userScheduleRepository;
        }
        public Task<UserSchedule> Handle(GetUserScheduleByIdQuery request,CancellationToken cancellationToken)
        {
            var result = _userScheduleRepository.GetUserScheduleById(request.id);
            return Task.FromResult(result);

        }
    }
}

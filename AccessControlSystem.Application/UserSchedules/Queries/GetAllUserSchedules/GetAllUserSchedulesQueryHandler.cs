using AccessControlSystem.Application.Abstract;
using AccessControlSystem.Contracts.UserSchedules;
using AccessControlSystem.Contracts;
using AccessControlSystem.Domain.Entities.UserSchedules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessControlSystem.Application.UserSchedules.Queries.GetAllUserSchedules
{
    public class GetAllUserSchedulesQueryHandler: IQueryHandler<GetAllUserSchedulesQuery,IEnumerable<UserSchedule>>
    {
        private readonly IUserScheduleRepository _userScheduleRepository;
        
        public GetAllUserSchedulesQueryHandler(IUserScheduleRepository userScheduleRepository)
        {
            _userScheduleRepository = userScheduleRepository;
        }

        public Task<IEnumerable<UserSchedule>> Handle(GetAllUserSchedulesQuery request,CancellationToken cancellationToken)
        {
            IEnumerable<UserSchedule> userSchedules= _userScheduleRepository.GetAllUserSchedules();
            return Task.FromResult(userSchedules);
        }
    }
}

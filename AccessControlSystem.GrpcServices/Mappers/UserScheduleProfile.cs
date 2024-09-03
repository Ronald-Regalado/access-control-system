using AccessControlSystem.Domain.Entities.Units;
using AccessControlSystem.GrpcServices.Protos;
using AutoMapper;

namespace AccessControlSystem.GrpcServices.Mappers
{
    public class UserScheduleProfile:Profile
    {
        public UserScheduleProfile()
        {
            CreateMap<Domain.Entities.UserSchedules.UserSchedule, GrpcServices.Protos.UserScheduleDTO>()
                .ForMember(t => t.Id, o => o.MapFrom(s => s.Id.ToString()))
                .ForMember(t => t.User, o => o.MapFrom(s => s.User))
                .ForMember(t=>t.UserId, o=>o.MapFrom(s=>s.UserId.ToString()))
                .ForMember(t=>t.Schedule, o=>o.MapFrom(s=>s.Schedule)
                );
            CreateMap<GrpcServices.Protos.UserScheduleDTO, Domain.Entities.UserSchedules.UserSchedule>()
                .ForMember(t => t.Id, o => o.MapFrom(s => new Guid(s.Id)))
                .ForMember(t=>t.User, o=> o.MapFrom(s=>s.User))
                .ForMember(t => t.UserId, o => o.MapFrom(s => new Guid(s.UserId)))
                .ForMember(t=>t.Schedule, o=>o.MapFrom(s=>s.Schedule)
                );




        }
    }
}

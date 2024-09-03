using AutoMapper;

namespace AccessControlSystem.GrpcServices.Mappers
{
    public class UserSessionProfile : Profile
    {
        public UserSessionProfile()
        {
            CreateMap<Domain.Entities.UserSessions.UserSession, GrpcServices.Protos.UserSessionDTO>()
                .ForMember(t => t.Id, o => o.MapFrom(s => s.Id.ToString()))
                .ForMember(t => t.User, o => o.MapFrom(s => s.User))
                .ForMember(t => t.UserId, o => o.MapFrom(s => s.UserId.ToString()))
                .ForMember(t => t.BusyUnit, o => o.MapFrom(s => s.BusyUnit))
                .ForMember(t => t.UnitId, o => o.MapFrom(s => s.UnitId.ToString()))
                .ForMember(t => t.StartTime, o => o.MapFrom(s => s.StartTime))
                .ForMember(t => t.EndTime, o => o.MapFrom(s => s.EndTime));

            CreateMap< GrpcServices.Protos.UserSessionDTO, Domain.Entities.UserSessions.UserSession>()
                 .ForMember(t => t.Id, o => o.MapFrom(s => new Guid(s.Id)))
                .ForMember(t => t.User, o => o.MapFrom(s => s.User))
                .ForMember(t => t.UserId, o => o.MapFrom(s => new Guid(s.UserId)))
                .ForMember(t => t.BusyUnit, o => o.MapFrom(s => s.BusyUnit))
                .ForMember(t => t.UnitId, o => o.MapFrom(s => new Guid(s.UnitId)))
                .ForMember(t => t.StartTime, o => o.MapFrom(s => s.StartTime))
                .ForMember(t => t.EndTime, o => o.MapFrom(s => s.EndTime));
        }
    }
}

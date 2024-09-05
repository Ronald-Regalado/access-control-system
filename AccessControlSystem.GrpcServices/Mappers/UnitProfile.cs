using AutoMapper;

namespace AccessControlSystem.GrpcServices.Mappers
{
    public class UnitProfile:Profile
    {
        public UnitProfile()
        {
            CreateMap<Domain.Entities.Units.Unit, Protos.UnitDTO>()
                .ForMember(t => t.Id, o => o.MapFrom(s => s.Id.ToString()))
                .ForMember(t => t.Maker, o => o.MapFrom(s => s.Maker))
                .ForMember(t => t.Code, o => o.MapFrom(s => s.Code))
                .ForMember(t => t.Product, o => o.MapFrom(s => s.Product))
                .ForMember(t => t.IsInUse, o => o.MapFrom(s => s.IsInUse));


            CreateMap<Protos.UnitDTO, Domain.Entities.Units.Unit>()
                .ForMember(t => t.Id, o => o.MapFrom(s => new Guid(s.Id)))
                .ForMember(t => t.Maker, o => o.MapFrom(s => s.Maker))
                .ForMember(t => t.Code, o => o.MapFrom(s => s.Code))
                .ForMember(t => t.Product, o => o.MapFrom(s => s.Product))
                .ForMember(t => t.IsInUse, o => o.MapFrom(s => s.IsInUse));

        }
    }
}

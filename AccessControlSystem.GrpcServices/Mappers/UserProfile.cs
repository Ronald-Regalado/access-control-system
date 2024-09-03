using AutoMapper;

namespace AccessControlSystem.GrpcServices.Mappers
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<Domain.Entities.Users.User, GrpcServices.Protos.UserDTO>()
                .ForMember(t => t.Id, o => o.MapFrom(s => s.Id.ToString()))
                .ForMember(t => t.FirstName, o => o.MapFrom(s => s.FirstName))
                .ForMember(t => t.LastName, o => o.MapFrom(s => s.LastName))
                .ForMember(t => t.Ci, o => o.MapFrom(s => s.CI))
                .ForMember(t => t.Location, o => o.MapFrom(s => new GrpcServices.Protos.Location()
                {
                    State = s.Location.State,
                    City = s.Location.City,
                    Address=s.Location.Address
                }
                ))
                .ForMember(t => t.SchoolLevel, o => o.MapFrom(s => s.SchoolLevel))
                .ForMember(t => t.Contact, o => o.MapFrom(s => new GrpcServices.Protos.Contact()
                {
                    Mail=s.Contact.Mail,
                    Telephone=s.Contact.Telephone
                }));

            CreateMap< GrpcServices.Protos.UserDTO, Domain.Entities.Users.User>()
               .ForMember(t => t.Id, o => o.MapFrom(s => new Guid(s.Id)))
                .ForMember(t => t.FirstName, o => o.MapFrom(s => s.FirstName))
                .ForMember(t => t.LastName, o => o.MapFrom(s => s.LastName))
                .ForMember(t => t.CI, o => o.MapFrom(s => s.Ci))
                .ForMember(t => t.Location, o => o.MapFrom(s => new Domain.ValueObjects.Location(
                    s.Location.State,
                    s.Location.City,
                    s.Location.Address
                    )))
                .ForMember(t => t.SchoolLevel, o => o.MapFrom(s => s.SchoolLevel))
                .ForMember(t => t.Contact, o => o.MapFrom(s => new Domain.ValueObjects.Contact(
                    s.Contact.Mail,
                    s.Contact.Telephone
                    )
                ));



        }
    }
}

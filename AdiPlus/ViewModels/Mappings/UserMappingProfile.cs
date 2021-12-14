using AdiPlus.Models;
using AutoMapper;

namespace AdiPlus.ViewModels.Mappings
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<DoctorViewModel, Doctor>()
                .ForMember(dest => dest.Id,
                    opt => opt.MapFrom
                        (src => src.Id))
                .ForMember(dest => dest.User,
                    opt => opt.MapFrom
                        (src => src.User))
                .ForMember(dest => dest.Specialization,
                    opt => opt.MapFrom
                        (src => src.Specialization))
                .ForMember(dest => dest.Name,
                    opt => opt.MapFrom
                        (src => src.Name))
                .ForMember(dest => dest.Surname,
                    opt => opt.MapFrom
                        (src => src.Surname))
                .ForMember(dest => dest.LastName,
                    opt => opt.MapFrom
                        (src => src.LastName))
                .ForMember(dest => dest.Cabinet,
                    opt => opt.Ignore())
                .ForMember(dest => dest.WorkSchedules,
                    opt => opt.Ignore()).ReverseMap();
            CreateMap<AppointmentViewModel, Appointment>()
                .ForMember(x => x.Client,
                    opt => opt.MapFrom(src => src.Client))
                .ForMember(x => x.DateStart,
                    opt => opt.MapFrom(src => src.DateStart))
                .ForMember(x => x.DateEnd,
                    opt => opt.MapFrom(src => src.DateEnd))
                .ForMember(x => x.Doctor,
                    opt => opt.MapFrom(src => src.Doctor))
                .ForMember(x => x.Id,
                    opt => opt.MapFrom(src => src.Id))
                .ForMember(x => x.Material, opt => opt.Ignore())
                .ForMember(x => x.MedicalCards, opt => opt.Ignore())
                .ForMember(x => x.Service, opt => opt.Ignore())
                .ForMember(x => x.ClientId,
                    opt => opt.Ignore()).ReverseMap();
            CreateMap<ServiceViewModel, Service>()
                .ForMember(x => x.Id,
                    opt => opt.MapFrom(src => src.Id))
                .ForMember(x => x.ServiceName,
                    opt => opt.MapFrom(src => src.ServiceName))
                .ForMember(x => x.Description,
                    opt => opt.MapFrom(src => src.Description))
                .ForMember(x => x.Price,
                    opt => opt.MapFrom(src => src.Price))
                .ForMember(x => x.Appointments, opt => opt.Ignore())
                .ForMember(x => x.Material, opt => opt.Ignore()).ReverseMap();
        }
    }
}
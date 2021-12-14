using AdiPlus.Models;
using AdiPlus.ViewModels.Admin;
using AutoMapper;

namespace AdiPlus.ViewModels.Mappings
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<MaterialViewModel, Material>()
                .ForMember(dest => dest.Id,
                    opt => opt.MapFrom
                        (src => src.Id))
                .ForMember(dest => dest.MaterialName,
                    opt => opt.MapFrom
                        (src => src.MaterialName))
                .ForMember(dest => dest.Price,
                    opt => opt.MapFrom
                        (src => src.Price))
                .ForMember(dest => dest.Quantity,
                    opt => opt.MapFrom
                        (src => src.Quantity))
                .ForMember(dest => dest.DeliveryDate,
                    opt => opt.MapFrom
                        (src => src.DeliveryDate))
                .ForMember(dest => dest.ExpirationDate,
                    opt => opt.MapFrom
                        (src => src.ExpirationDate))
                .ForMember(dest => dest.Appointment,
                    opt => opt.Ignore())
                .ForMember(dest => dest.Service,
                    opt => opt.Ignore()).ReverseMap();
            
            CreateMap<ServiceViewModel, Service>()
                .ForMember(dest => dest.Id,
                    opt => opt.MapFrom
                        (src => src.Id))
                .ForMember(dest => dest.ServiceName,
                    opt => opt.MapFrom
                        (src => src.ServiceName))
                .ForMember(dest => dest.Description,
                    opt => opt.MapFrom
                        (src => src.Description))
                .ForMember(dest => dest.Price,
                    opt => opt.MapFrom
                        (src => src.Price))
                .ForMember(dest => dest.Material,
                    opt => opt.MapFrom
                        (src => src.Material))
                .ForMember(dest => dest.Appointments,
                    opt => opt.Ignore()).ReverseMap();
        }
    }
}
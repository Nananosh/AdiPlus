using AdiPlus.Models;
using AdiPlus.ViewModels.Admin;
using AutoMapper;

namespace AdiPlus.ViewModels.Mappings
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<DoctorViewModel, Doctor>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(dvm => dvm.Id))
                .ForMember(dest => dest.User, opt => opt.MapFrom(dvm => dvm.User))
                .ForMember(dest => dest.Specialization, opt => opt.MapFrom(dvm => dvm.Specialization))
                .ForMember(dest => dest.SpecializationId, opt => opt.MapFrom(dvm => dvm.SpecializationId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(dvm => dvm.Name))
                .ForMember(dest => dest.Surname, opt => opt.MapFrom(dvm => dvm.Surname))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(dvm => dvm.LastName))
                .ForMember(dest => dest.Cabinet, opt => opt.MapFrom(dvm => dvm.Cabinet))
                .ForMember(dest => dest.CabinetId, opt => opt.MapFrom(dvm => dvm.CabinetId))
                .ForMember(dest => dest.WorkSchedules, opt => opt.Ignore()).ReverseMap();
            CreateMap<AppointmentViewModel, Appointment>()
                .ForMember(x => x.Client, opt => opt.MapFrom(src => src.Client))
                .ForMember(x => x.DateStart, opt => opt.MapFrom(src => src.DateStart))
                .ForMember(x => x.DateEnd, opt => opt.MapFrom(src => src.DateEnd))
                .ForMember(x => x.Doctor, opt => opt.MapFrom(src => src.Doctor))
                .ForMember(x => x.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(x => x.Material, opt => opt.Ignore())
                .ForMember(x => x.MedicalCards, opt => opt.Ignore())
                .ForMember(x => x.Service, opt => opt.Ignore())
                .ForMember(x => x.ClientId, opt => opt.Ignore()).ReverseMap();
            CreateMap<ServiceViewModel, Service>()
                .ForMember(x => x.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(x => x.ServiceName, opt => opt.MapFrom(src => src.ServiceName))
                .ForMember(x => x.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(x => x.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(x => x.Materials, opt => opt.MapFrom(src => src.Materials))
                .ForMember(dest => dest.SpecializationId, opt => opt.MapFrom(src => src.SpecializationId))
                .ForMember(dest => dest.Specialization, opt => opt.Ignore())
                .ForMember(x => x.Appointments, opt => opt.Ignore()).ReverseMap();
            CreateMap<MaterialViewModel, Material>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.MaterialName,opt => opt.MapFrom(src => src.MaterialName))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.Quantity,opt => opt.MapFrom(src => src.Quantity))
                .ForMember(dest => dest.DeliveryDate, opt => opt.MapFrom(src => src.DeliveryDate))
                .ForMember(dest => dest.ExpirationDate,opt => opt.MapFrom(src => src.ExpirationDate))
                .ForMember(dest => dest.Appointment, opt => opt.Ignore())
                .ForMember(dest => dest.Services, opt => opt.Ignore()).ReverseMap();
            CreateMap<SpecializationViewModel, Specialization>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.SpecializationName, opt => opt.MapFrom(src => src.SpecializationName))
                .ForMember(dest => dest.Doctors, opt => opt.Ignore()).ReverseMap();
            CreateMap<CabinetViewModel, Cabinet>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.CabinetNumber, opt => opt.MapFrom(src => src.CabinetNumber))
                .ForMember(dest => dest.Doctors, opt => opt.Ignore()).ReverseMap();
            CreateMap<MedicalCardViewModel, MedicalCard>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Recommendation, opt => opt.MapFrom(src => src.Recommendation))
                .ForMember(dest => dest.Appointment, opt => opt.MapFrom(src => src.Appointment))
                .ForMember(dest => dest.AppointmentId, opt => opt.MapFrom(src => src.AppointmentId)).ReverseMap();
            CreateMap<MedicalCard, AppintmentResultViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Recommendation, opt => opt.MapFrom(src => src.Recommendation))
                .ForMember(dest => dest.Appointment, opt => opt.MapFrom(src => src.Appointment))
                .ForMember(dest => dest.medicalCardViewModels, opt => opt.Ignore())
                .ForMember(dest => dest.AppointmentId, opt => opt.MapFrom(src => src.AppointmentId)).ReverseMap();
            CreateMap<AppointmentMaterialUsedViewModel, AppointmentMaterialUsed>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
                .ForMember(dest => dest.MaterialId, opt => opt.MapFrom(src => src.MaterialId))
                .ForMember(dest => dest.Material, opt => opt.Ignore())
                .ForMember(dest => dest.Appointment, opt => opt.Ignore())
                .ForMember(dest => dest.AppointmentId, opt => opt.MapFrom(src => src.AppointmentId)).ReverseMap();
        }
    }
}
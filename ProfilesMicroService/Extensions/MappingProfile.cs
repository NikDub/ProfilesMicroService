using AutoMapper;
using ProfilesMicroService.Application.Dto;
using ProfilesMicroService.Application.Dto.Doctor;
using ProfilesMicroService.Application.Dto.Patient;
using ProfilesMicroService.Application.Dto.Receptionist;
using ProfilesMicroService.Domain.Entities.Models;

namespace ProfilesMicroService.Api.Extensions;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ReceptionistDto, Receptionist>().ReverseMap();
        CreateMap<ReceptionistForCreateDto, Receptionist>().ReverseMap();
        CreateMap<ReceptionistForUpdateDto, Receptionist>().ReverseMap();

        CreateMap<PatientDto, Patient>().ReverseMap();
        CreateMap<PatientForCreateDto, Patient>().ReverseMap();
        CreateMap<PatientForUpdateDto, Patient>().ReverseMap();

        CreateMap<DoctorDto, Doctor>()
            .ForMember(r => r.SpecializationId, t => t.MapFrom(r => r.Specialization.Id))
            .ForMember(r => r.SpecializationName, t => t.MapFrom(r => r.Specialization.Name))
            .ReverseMap();
        CreateMap<DoctorForCreateDto, Doctor>().ReverseMap();
        CreateMap<DoctorForUpdateDto, Doctor>().ReverseMap();

        CreateMap<StatusDto, Status>().ReverseMap();
    }
}
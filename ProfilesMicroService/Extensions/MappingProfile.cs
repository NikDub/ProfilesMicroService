using AutoMapper;
using ProfilesMicroService.Application.DTO.Patient;
using ProfilesMicroService.Application.DTO.Receptionist;
using ProfilesMicroService.Domain.Entities.Models;

namespace ProfilesMicroService.Api.Extensions
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ReceptionistDTO, Receptionist>().ReverseMap();
            CreateMap<ReceptionistForCreateDTO, Receptionist>().ReverseMap();
            CreateMap<ReceptionistForUpdateDTO, Receptionist>().ReverseMap();

            CreateMap<PatientDTO, Patient>().ReverseMap();
            CreateMap<PatientForCreateDTO, Patient>().ReverseMap();
            CreateMap<PatientForUpdateDTO, Patient>().ReverseMap();
        }
    }
}

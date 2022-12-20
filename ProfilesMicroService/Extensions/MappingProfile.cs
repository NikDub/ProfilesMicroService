
using AutoMapper;
using ProfilesMicroService.Application.Services;
using ProfilesMicroService.Domain.Entities.Models;

namespace ProfilesMicroService.Api.Extensions
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProfileDTO, Receptionist>().ReverseMap();
        }
    }
}

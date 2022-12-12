using ProfilesMicroService.Application.Services.DTO;
using ProfilesMicroService.Domain.Entities.Models;

namespace ProfilesMicroService.Application.Services.Abstractions
{
    public interface IReceptionistService
    {
        Task<Receptionist> CreateAsync(ProfileDTO model);
        Task<bool> DeleteAsync(string id);
        Task<Receptionist> EditAsync(string id, ProfileDTO model);
        Task<List<Receptionist>> GetAsync();
        Task<Receptionist> GetAsync(string id);
    }
}

using ProfilesMicroService.Application.Services.DTO.Profile;
using ProfilesMicroService.Domain.Entities.Models;

namespace ProfilesMicroService.Application.Services.Abstractions
{
    public interface IReceptionistService
    {
        Task<ReceptionistDTO> CreateAsync(ReceptionistForCreateDTO model);
        Task<bool> DeleteAsync(string id);
        Task<ReceptionistDTO> EditAsync(string id, ReceptionistForUpdateDTO model);
        Task<List<ReceptionistDTO>> GetAsync();
        Task<ReceptionistDTO> GetAsync(string id);
    }
}

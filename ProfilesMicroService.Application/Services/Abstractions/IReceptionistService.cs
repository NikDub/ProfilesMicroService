using ProfilesMicroService.Application.DTO.Receptionist;

namespace ProfilesMicroService.Application.Services.Abstractions
{
    public interface IReceptionistService
    {
        Task<ReceptionistDTO> CreateAsync(ReceptionistForCreateDTO model);
        Task<bool> DeleteAsync(string id);
        Task<ReceptionistDTO> UpdateAsync(string id, ReceptionistForUpdateDTO model);
        Task<List<ReceptionistDTO>> GetAsync();
        Task<ReceptionistDTO> GetByIdAsync(string id);
    }
}

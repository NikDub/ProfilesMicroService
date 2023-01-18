using ProfilesMicroService.Application.Dto.Receptionist;

namespace ProfilesMicroService.Application.Services.Abstractions;

public interface IReceptionistService
{
    Task<ReceptionistDto> CreateAsync(ReceptionistForCreateDto model);
    Task<bool> DeleteAsync(string id);
    Task<ReceptionistDto> UpdateAsync(string id, ReceptionistForUpdateDto model);
    Task<List<ReceptionistDto>> GetAsync();
    Task<ReceptionistDto> GetByIdAsync(string id);
}
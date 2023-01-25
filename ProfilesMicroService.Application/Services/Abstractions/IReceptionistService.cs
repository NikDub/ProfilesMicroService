using ProfilesMicroService.Application.Dto.Receptionist;

namespace ProfilesMicroService.Application.Services.Abstractions;

public interface IReceptionistService
{
    Task<ReceptionistDto> CreateAsync(ReceptionistForCreateDto model);
    Task<bool> DeleteAsync(Guid id);
    Task<ReceptionistDto> UpdateAsync(Guid id, ReceptionistForUpdateDto model);
    Task<List<ReceptionistDto>> GetAsync();
    Task<ReceptionistDto> GetByIdAsync(Guid id);
}
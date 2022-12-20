using ProfilesMicroService.Application.DTO.Patient;
using ProfilesMicroService.Domain.Entities.Enums;

namespace ProfilesMicroService.Application.Services.Abstractions
{
    public interface IDoctorService
    {
        Task<DoctorDTO> CreateAsync(DoctorForCreateDTO model);
        Task<bool> DeleteAsync(string id);
        Task<DoctorDTO> UpdateAsync(string id, DoctorForUpdateDTO model);
        Task<DoctorDTO> ChangeStatusAsync(string id, string status);
        Task<List<DoctorDTO>> GetAsync();
        Task<DoctorDTO> GetByIdAsync(string id);
        Task<List<DoctorDTO>> GetDoctorsByStatusAsync(string status);
    }
}

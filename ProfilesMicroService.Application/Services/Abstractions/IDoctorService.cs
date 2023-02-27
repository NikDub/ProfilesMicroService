using ProfilesMicroService.Application.Dto.Doctor;

namespace ProfilesMicroService.Application.Services.Abstractions;

public interface IDoctorService
{
    Task<DoctorDto> CreateAsync(DoctorForCreateDto model);
    Task<DoctorDto> UpdateAsync(Guid id, DoctorForUpdateDto model);
    Task<DoctorDto> ChangeStatusAsync(Guid id, string status);
    Task<List<DoctorDto>> GetAsync();
    Task<DoctorDto> GetByIdAsync(Guid id);
    Task<List<DoctorDto>> GetDoctorsByStatusAsync(string status);
}
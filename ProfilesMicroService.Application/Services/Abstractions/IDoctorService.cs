using ProfilesMicroService.Application.Dto.Doctor;

namespace ProfilesMicroService.Application.Services.Abstractions;

public interface IDoctorService
{
    Task<DoctorDto> CreateAsync(DoctorForCreateDto model);
    Task<DoctorDto> UpdateAsync(string id, DoctorForUpdateDto model);
    Task<DoctorDto> ChangeStatusAsync(string id, string status);
    Task<List<DoctorDto>> GetAsync();
    Task<DoctorDto> GetByIdAsync(string id);
    Task<List<DoctorDto>> GetDoctorsByStatusAsync(string status);
}
using ProfilesMicroService.Domain.Entities.Models;

namespace ProfilesMicroService.Infrastructure.Repository.Abstractions;

public interface IDoctorRepository
{
    Task<IEnumerable<Doctor>> GetAllAsync();
    Task<Doctor> GetByIdAsync(Guid id);
    Task<IEnumerable<Doctor>> GetByStatusAsync(string status);
    Task InsertAsync(Doctor patient);
    Task DeleteAsync(Guid id);
    Task SaveAsync();
    Task UpdateSpecializationNameAsync(Guid specializationId, string specializationName);
}
using ProfilesMicroService.Domain.Entities.Models;

namespace ProfilesMicroService.Infrastructure.Repository.Abstractions
{
    public interface IDoctorRepository
    {
        Task<IEnumerable<Doctor>> GetAllAsync();
        Task<Doctor> GetByIdAsync(string id);
        Task<IEnumerable<Doctor>> GetByStatusAsync(string status);
        Task InsertAsync(Doctor patient);
        Task UpdateAsync(Doctor patient);
        Task DeleteAsync(string id);
        Task SaveAsync();
    }
}

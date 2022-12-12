using ProfilesMicroService.Domain.Entities.Models;

namespace ProfilesMicroService.Application.Services.Abstractions
{
    public interface IPatientRepository
    {
        Task<IEnumerable<Patient>> GetAllAsync();
        Task<Patient> GetByIdAsync(string id);
        Task InsertAsync(Patient patient);
        void Update(Patient patient);
        Task DeleteAsync(string id);
        Task SaveAsync();
    }
}

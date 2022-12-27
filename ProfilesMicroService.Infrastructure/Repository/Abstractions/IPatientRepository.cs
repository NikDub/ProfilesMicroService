using ProfilesMicroService.Domain.Entities.Models;
using System.Threading;

namespace ProfilesMicroService.Infrastructure.Repository.Abstractions
{
    public interface IPatientRepository
    {
        Task<IEnumerable<Patient>> GetAllAsync(CancellationToken cancellationToken);
        Task<IEnumerable<Patient>> GetAllWithoutAccountAsync(CancellationToken cancellationToken);
        Task<Patient> GetByIdAsync(string id, CancellationToken cancellationToken);
        Task InsertAsync(Patient patient, CancellationToken cancellationToken);
        Task UpdateAsync(Patient patient, CancellationToken cancellationToken);
        Task DeleteAsync(string id, CancellationToken cancellationToken);
    }
}

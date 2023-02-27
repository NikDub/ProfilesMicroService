using ProfilesMicroService.Domain.Entities.Models;

namespace ProfilesMicroService.Infrastructure.Repository.Abstractions;

public interface IPatientRepository
{
    Task<IEnumerable<Patient>> GetAllAsync(CancellationToken cancellationToken);
    Task<Patient> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<Patient> GetByAccountIdAsync(Guid accountId, CancellationToken cancellationToken);
    Task<IEnumerable<Patient>> GetAllWithoutAccountAsync(CancellationToken cancellationToken);
    Task InsertAsync(Patient patient, CancellationToken cancellationToken);
    Task UpdateAsync(Patient patient, CancellationToken cancellationToken);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken);
}
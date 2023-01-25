using ProfilesMicroService.Domain.Entities.Models;

namespace ProfilesMicroService.Infrastructure.Repository.Abstractions;

public interface IReceptionistRepository
{
    Task<IEnumerable<Receptionist>> GetAllAsync();
    Task<Receptionist> GetByIdAsync(Guid id);
    Task InsertAsync(Receptionist patient);
    Task DeleteAsync(Guid id);
    Task SaveAsync();
}
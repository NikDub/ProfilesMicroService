using ProfilesMicroService.Domain.Entities.Models;

namespace ProfilesMicroService.Infrastructure.Repository.Abstractions
{
    public interface IReceptionistRepository
    {
        Task<IEnumerable<Receptionist>> GetAllAsync();
        Task<Receptionist> GetByIdAsync(string id);
        Task InsertAsync(Receptionist patient);
        Task UpdateAsync(Receptionist patient);
        Task DeleteAsync(string id);
        Task SaveAsync();
    }
}

using ProfilesMicroService.Domain.Entities.Models;
using System.Threading;

namespace ProfilesMicroService.Infrastructure.Repository.Abstractions
{
    public interface IStatusRepository
    {
        Task<IEnumerable<Status>> GetAllAsync();
        Task<Status> GetByIdAsync(string id);
        Task<Status> GetByNameAsync(string name);
    }
}

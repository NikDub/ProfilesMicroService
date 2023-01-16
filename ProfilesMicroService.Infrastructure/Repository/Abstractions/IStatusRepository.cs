using ProfilesMicroService.Domain.Entities.Models;

namespace ProfilesMicroService.Infrastructure.Repository.Abstractions;

public interface IStatusRepository
{
    Task<Status> GetByNameAsync(string name);
}
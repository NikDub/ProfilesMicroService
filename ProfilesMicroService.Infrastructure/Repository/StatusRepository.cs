using Microsoft.EntityFrameworkCore;
using ProfilesMicroService.Domain.Entities.Models;
using ProfilesMicroService.Infrastructure.Repository.Abstractions;

namespace ProfilesMicroService.Infrastructure.Repository;

public class StatusRepository : IStatusRepository
{
    private readonly ApplicationDbContext _dbContext;

    public StatusRepository(ApplicationDbContext dBContext)
    {
        _dbContext = dBContext;
    }

    public async Task<IEnumerable<Status>> GetAllAsync()
    {
        return await _dbContext.Status.ToListAsync();
    }

    public async Task<Status> GetByIdAsync(string id)
    {
        return await _dbContext.Status.FindAsync(id);
    }

    public async Task<Status> GetByNameAsync(string name)
    {
        return await _dbContext.Status.FindAsync(name);
    }
}
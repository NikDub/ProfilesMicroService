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
        return await _dbContext.Statuses.ToListAsync();
    }

    public async Task<Status> GetByIdAsync(Guid id)
    {
        return await _dbContext.Statuses.FindAsync(id);
    }

    public async Task<Status> GetByNameAsync(string name)
    {
        return await _dbContext.Statuses.FirstOrDefaultAsync(r=>r.Name == name);
    }
}
using Microsoft.EntityFrameworkCore;
using ProfilesMicroService.Domain.Entities.Models;
using ProfilesMicroService.Infrastructure;
using ProfilesMicroService.Infrastructure.Repository.Abstractions;

namespace ProfilesMicroService.Application.Services
{
    public class StatusRepository : IStatusRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public StatusRepository(ApplicationDBContext dBContext)
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
}

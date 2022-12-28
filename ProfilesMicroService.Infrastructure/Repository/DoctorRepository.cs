using Microsoft.EntityFrameworkCore;
using ProfilesMicroService.Domain.Entities.Models;
using ProfilesMicroService.Infrastructure;
using ProfilesMicroService.Infrastructure.Repository.Abstractions;

namespace ProfilesMicroService.Application.Services
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public DoctorRepository(ApplicationDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        public async Task<IEnumerable<Doctor>> GetAllAsync()
        {
            return await _dbContext.Doctors.ToListAsync();
        }


        public async Task<Doctor> GetByIdAsync(string id)
        {
            return await _dbContext.Doctors.FindAsync(id);
        }

        public async Task InsertAsync(Doctor doctor)
        {
            await _dbContext.Doctors.AddAsync(doctor);
            await _dbContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(Doctor doctor)
        {
            _dbContext.Entry(doctor).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var doctor = await _dbContext.Doctors.FindAsync(id);
            _dbContext.Doctors.Remove(doctor);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Doctor>> GetByStatusAsync(string status)
        {
            return await _dbContext.Doctors.Where(r => r.Status.Name == status).ToListAsync();
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}

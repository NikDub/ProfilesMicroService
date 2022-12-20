using Microsoft.EntityFrameworkCore;
using ProfilesMicroService.Application.Services.Abstractions;
using ProfilesMicroService.Domain.Entities.Models;
using ProfilesMicroService.Infrastructure;

namespace ProfilesMicroService.Application.Services
{
    public class PatientRepository : IPatientRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public PatientRepository(ApplicationDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        public async Task<IEnumerable<Patient>> GetAllAsync()
        {
            return await _dbContext.Patients.ToListAsync();
        }

        public async Task<Patient> GetByIdAsync(string id)
        {
            return await _dbContext.Patients.FindAsync(id);
        }

        public async Task InsertAsync(Patient patient)
        {
            await _dbContext.Patients.AddAsync(patient);
        }
        public void Update(Patient patient)
        {
            _dbContext.Entry(patient).State = EntityState.Modified;
        }

        public async Task DeleteAsync(string id)
        {
            var patient = await _dbContext.Patients.FindAsync(id);
            _dbContext.Patients.Remove(patient);
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

    }
}

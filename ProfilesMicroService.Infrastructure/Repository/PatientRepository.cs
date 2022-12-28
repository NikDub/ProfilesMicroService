using Microsoft.EntityFrameworkCore;
using ProfilesMicroService.Domain.Entities.Models;
using ProfilesMicroService.Infrastructure;
using ProfilesMicroService.Infrastructure.Repository.Abstractions;

namespace ProfilesMicroService.Application.Services
{
    public class PatientRepository : IPatientRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public PatientRepository(ApplicationDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        public async Task<IEnumerable<Patient>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _dbContext.Patients.ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<Patient>> GetAllWithoutAccountAsync(CancellationToken cancellationToken)
        {
            return await _dbContext.Patients.Where(r => !r.IsLinkedToAccount).ToListAsync(cancellationToken);
        }

        public async Task<Patient> GetByIdAsync(string id, CancellationToken cancellationToken)
        {
            return await _dbContext.Patients.FindAsync(id, cancellationToken);
        }

        public async Task InsertAsync(Patient patient, CancellationToken cancellationToken)
        {
            await _dbContext.Patients.AddAsync(patient, cancellationToken);
            await _dbContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(Patient patient, CancellationToken cancellationToken)
        {
            _dbContext.Entry(patient).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(string id, CancellationToken cancellationToken)
        {
            var patient = await _dbContext.Patients.FindAsync(id, cancellationToken);
            _dbContext.Patients.Remove(patient);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}

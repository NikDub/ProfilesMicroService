using Microsoft.EntityFrameworkCore;
using ProfilesMicroService.Domain.Entities.Models;
using ProfilesMicroService.Infrastructure.Repository.Abstractions;

namespace ProfilesMicroService.Infrastructure.Repository;

public class PatientRepository : IPatientRepository
{
    private readonly ApplicationDbContext _dbContext;

    public PatientRepository(ApplicationDbContext dBContext)
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

    public async Task<Patient> GetByAccountIdAsync(Guid accountId, CancellationToken cancellationToken)
    {
        return await _dbContext.Patients.FirstOrDefaultAsync(r=>r.AccountId == accountId, cancellationToken);
    }

    public async Task<Patient> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _dbContext.Patients.FindAsync(id, cancellationToken);
    }

    public async Task InsertAsync(Patient patient, CancellationToken cancellationToken)
    {
        await _dbContext.Patients.AddAsync(patient, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(Patient patient, CancellationToken cancellationToken)
    {
        _dbContext.Entry(patient).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var patient = await _dbContext.Patients.FindAsync(id, cancellationToken);
        if (patient != null) _dbContext.Patients.Remove(patient);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
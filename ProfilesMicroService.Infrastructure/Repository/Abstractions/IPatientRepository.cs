﻿using ProfilesMicroService.Domain.Entities.Models;

namespace ProfilesMicroService.Infrastructure.Repository.Abstractions;

public interface IPatientRepository
{
    Task<IEnumerable<Patient>> GetAllAsync(CancellationToken cancellationToken);
    Task<Patient> GetByIdAsync(string id, CancellationToken cancellationToken);
    Task<Patient> GetByAccountIdAsync(string accountId, CancellationToken cancellationToken);
    Task<IEnumerable<Patient>> GetAllWithoutAccountAsync(CancellationToken cancellationToken);
    Task InsertAsync(Patient patient, CancellationToken cancellationToken);
    Task UpdateAsync(Patient patient, CancellationToken cancellationToken);
    Task DeleteAsync(string id, CancellationToken cancellationToken);
}
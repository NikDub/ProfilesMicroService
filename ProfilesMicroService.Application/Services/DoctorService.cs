using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProfilesMicroService.Application.DTO.Patient;
using ProfilesMicroService.Application.Services.Abstractions;
using ProfilesMicroService.Domain.Entities.Enums;
using ProfilesMicroService.Domain.Entities.Models;
using ProfilesMicroService.Infrastructure;

namespace ProfilesMicroService.Application.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly ApplicationDBContext _db;
        private readonly IMapper _mapper;

        public DoctorService(ApplicationDBContext dBContext, IMapper mapper)
        {
            _db = dBContext;
            _mapper = mapper;
        }

        public async Task<DoctorDTO> ChangeStatusAsync(string id, string status)
        {
            var doctor = _db.Doctors.FirstOrDefault(e => e.Id == id);
            if (doctor == null)
                return null;

            var newStatus = await _db.Statuss.FirstOrDefaultAsync(r=>r.Name == status);
            if (newStatus == null)
                return null;

            doctor.StatusId = newStatus.Id;

            await _db.SaveChangesAsync();
            return _mapper.Map<DoctorDTO>(doctor);
        }

        public async Task<DoctorDTO> CreateAsync(DoctorForCreateDTO model)
        {
            if (model == null)
                return null;

            var doctorMap = _mapper.Map<Doctor>(model);
            _db.Doctors.Add(doctorMap);
            await _db.SaveChangesAsync();
            return _mapper.Map<DoctorDTO>(doctorMap);
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var doctor = await _db.Doctors.FirstOrDefaultAsync(re => re.Id == id);

            if (doctor == null)
                return false;

            _db.Doctors.Remove(doctor);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<DoctorDTO> UpdateAsync(string id, DoctorForUpdateDTO model)
        {
            if (model == null)
                return null;

            var doctor = _db.Doctors.FirstOrDefault(e => e.Id == id);
            if (doctor == null)
                return null;

            _mapper.Map(model, doctor);
            await _db.SaveChangesAsync();
            return _mapper.Map<DoctorDTO>(doctor);
        }

        public async Task<List<DoctorDTO>> GetAsync() 
            => _mapper.Map<List<DoctorDTO>>(await _db.Doctors.ToListAsync());

        public async Task<DoctorDTO> GetByIdAsync(string id)
            => _mapper.Map<DoctorDTO>(await _db.Doctors.FirstOrDefaultAsync(e => e.Id == id));

        public async Task<List<DoctorDTO>> GetDoctorsByStatusAsync(string status)
            => _mapper.Map<List<DoctorDTO>>(await _db.Doctors.Where(r => r.Status.Name == status).ToListAsync());

    }
}

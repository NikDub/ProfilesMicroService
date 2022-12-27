using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProfilesMicroService.Application.DTO.Patient;
using ProfilesMicroService.Application.Services.Abstractions;
using ProfilesMicroService.Domain.Entities.Enums;
using ProfilesMicroService.Domain.Entities.Models;
using ProfilesMicroService.Infrastructure;
using ProfilesMicroService.Infrastructure.Repository.Abstractions;

namespace ProfilesMicroService.Application.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IStatusRepository _statusRepository;
        private readonly IMapper _mapper;

        public DoctorService(IDoctorRepository doctorRepository, IStatusRepository statusRepository, IMapper mapper)
        {
            _doctorRepository = doctorRepository;
            _statusRepository = statusRepository;
            _mapper = mapper;
        }

        public async Task<DoctorDTO> ChangeStatusAsync(string id, string status)
        {
            var doctor = await _doctorRepository.GetByIdAsync(id);
            if (doctor == null)
                return null;

            var newStatus = await _statusRepository.GetByNameAsync(status);
            if (newStatus == null)
                return null;

            doctor.StatusId = newStatus.Id;

            await _doctorRepository.SaveAsync();
            return _mapper.Map<DoctorDTO>(doctor);
        }

        public async Task<DoctorDTO> CreateAsync(DoctorForCreateDTO model)
        {
            if (model == null)
                return null;

            var doctorMap = _mapper.Map<Doctor>(model);
            await _doctorRepository.InsertAsync(doctorMap);
            return _mapper.Map<DoctorDTO>(doctorMap);
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var doctor = await _doctorRepository.GetByIdAsync(id);

            if (doctor == null)
                return false;

            await _doctorRepository.DeleteAsync(id);
            return true;
        }

        public async Task<DoctorDTO> UpdateAsync(string id, DoctorForUpdateDTO model)
        {
            if (model == null)
                return null;

            var doctor = await _doctorRepository.GetByIdAsync(id);
            if (doctor == null)
                return null;

            _mapper.Map(model, doctor);
            await _doctorRepository.SaveAsync();
            return _mapper.Map<DoctorDTO>(doctor);
        }

        public async Task<List<DoctorDTO>> GetAsync() 
            => _mapper.Map<List<DoctorDTO>>(await _doctorRepository.GetAllAsync());

        public async Task<DoctorDTO> GetByIdAsync(string id)
            => _mapper.Map<DoctorDTO>(await _doctorRepository.GetByIdAsync(id));

        public async Task<List<DoctorDTO>> GetDoctorsByStatusAsync(string status)
            => _mapper.Map<List<DoctorDTO>>(await _doctorRepository.GetByStatusAsync(status));

    }
}

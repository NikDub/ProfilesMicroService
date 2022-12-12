using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProfilesMicroService.Application.Services.Abstractions;
using ProfilesMicroService.Application.Services.DTO;
using ProfilesMicroService.Domain.Entities.Models;
using ProfilesMicroService.Infrastructure;

namespace ProfilesMicroService.Application.Services
{
    public class ProfileService : IReceptionistService
    {
        private readonly ApplicationDBContext _db;
        private readonly IMapper _mapper;

        public ProfileService(ApplicationDBContext dBContext, IMapper mapper)
        {
            _db = dBContext;
            _mapper = mapper;
        }

        public async Task<Receptionist> CreateAsync(ProfileDTO model)
        {
            var receptionistMap = _mapper.Map<Receptionist>(model);
            _db.Receptionists.Add(receptionistMap);
            await _db.SaveChangesAsync();
            return receptionistMap;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var reseptionist = await _db.Receptionists.FirstOrDefaultAsync(re => re.Id == id);

            if (reseptionist == null)
                return false;

            _db.Receptionists.Remove(reseptionist);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<Receptionist> EditAsync(string id, ProfileDTO model)
        {
            var reseptionist = _db.Receptionists.FirstOrDefault(e => e.Id == id);
            if (reseptionist == null)
                return null;

            reseptionist.OfficeId = model.OfficeId;
            reseptionist.FirstName = model.FirstName;
            reseptionist.LastName = model.LastName;
            reseptionist.MiddleName = model.MiddleName;
            await _db.SaveChangesAsync();
            return reseptionist;
        }

        public async Task<List<Receptionist>> GetAsync()
        {
            return await _db.Receptionists.ToListAsync();
        }

        public async Task<Receptionist> GetAsync(string id)
        {
            return await _db.Receptionists.FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}

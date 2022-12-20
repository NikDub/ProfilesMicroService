using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProfilesMicroService.Application.DTO.Receptionist;
using ProfilesMicroService.Application.Services.Abstractions;
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

        public async Task<ReceptionistDTO> CreateAsync(ReceptionistForCreateDTO model)
        {
            if (model == null)
                return null;

            var receptionistMap = _mapper.Map<Receptionist>(model);
            _db.Receptionists.Add(receptionistMap);
            await _db.SaveChangesAsync();
            return _mapper.Map<ReceptionistDTO>(receptionistMap);
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

        public async Task<ReceptionistDTO> EditAsync(string id, ReceptionistForUpdateDTO model)
        {
            if (model == null)
                return null;

            var reseptionist = _db.Receptionists.FirstOrDefault(e => e.Id == id);
            if (reseptionist == null)
                return null;

            _mapper.Map(model, reseptionist);
            await _db.SaveChangesAsync();
            return _mapper.Map<ReceptionistDTO>(reseptionist);
        }

        public async Task<List<ReceptionistDTO>> GetAsync() => _mapper.Map<List<ReceptionistDTO>>(await _db.Receptionists.ToListAsync());

        public async Task<ReceptionistDTO> GetAsync(string id) => _mapper.Map<ReceptionistDTO>(await _db.Receptionists.FirstOrDefaultAsync(e => e.Id == id));
    }
}

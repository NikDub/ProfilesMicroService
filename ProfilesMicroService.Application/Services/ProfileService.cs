using AutoMapper;
using ProfilesMicroService.Application.DTO.Receptionist;
using ProfilesMicroService.Application.Services.Abstractions;
using ProfilesMicroService.Domain.Entities.Models;
using ProfilesMicroService.Infrastructure.Repository.Abstractions;

namespace ProfilesMicroService.Application.Services
{
    public class ProfileService : IReceptionistService
    {
        private readonly IReceptionistRepository _receptionistRepository;
        private readonly IMapper _mapper;

        public ProfileService(IReceptionistRepository receptionistRepository, IMapper mapper)
        {
            _receptionistRepository = receptionistRepository;
            _mapper = mapper;
        }

        public async Task<ReceptionistDTO> CreateAsync(ReceptionistForCreateDTO model)
        {
            if (model == null)
                return null;

            var receptionistMap = _mapper.Map<Receptionist>(model);
            await _receptionistRepository.InsertAsync(receptionistMap);
            return _mapper.Map<ReceptionistDTO>(receptionistMap);
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var reseptionist = await _receptionistRepository.GetByIdAsync(id);

            if (reseptionist == null)
                return false;

            await _receptionistRepository.DeleteAsync(id);
            return true;
        }

        public async Task<ReceptionistDTO> UpdateAsync(string id, ReceptionistForUpdateDTO model)
        {
            if (model == null)
                return null;

            var reseptionist = await _receptionistRepository.GetByIdAsync(id);
            if (reseptionist == null)
                return null;

            _mapper.Map(model, reseptionist);
            await _receptionistRepository.SaveAsync();
            return _mapper.Map<ReceptionistDTO>(reseptionist);
        }

        public async Task<List<ReceptionistDTO>> GetAsync() => _mapper.Map<List<ReceptionistDTO>>(await _receptionistRepository.GetAllAsync());

        public async Task<ReceptionistDTO> GetByIdAsync(string id) => _mapper.Map<ReceptionistDTO>(await _receptionistRepository.GetByIdAsync(id));
    }
}

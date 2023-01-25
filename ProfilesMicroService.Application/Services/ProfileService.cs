using AutoMapper;
using ProfilesMicroService.Application.Dto.Receptionist;
using ProfilesMicroService.Application.Services.Abstractions;
using ProfilesMicroService.Domain.Entities.Models;
using ProfilesMicroService.Infrastructure.Repository.Abstractions;

namespace ProfilesMicroService.Application.Services;

public class ProfileService : IReceptionistService
{
    private readonly IMapper _mapper;
    private readonly IReceptionistRepository _receptionistRepository;

    public ProfileService(IReceptionistRepository receptionistRepository, IMapper mapper)
    {
        _receptionistRepository = receptionistRepository;
        _mapper = mapper;
    }

    public async Task<ReceptionistDto> CreateAsync(ReceptionistForCreateDto model)
    {
        if (model == null)
            return null;

        var receptionistMap = _mapper.Map<Receptionist>(model);
        await _receptionistRepository.InsertAsync(receptionistMap);
        return _mapper.Map<ReceptionistDto>(receptionistMap);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var receptionist = await _receptionistRepository.GetByIdAsync(id);

        if (receptionist == null)
            return false;

        await _receptionistRepository.DeleteAsync(id);
        return true;
    }

    public async Task<ReceptionistDto> UpdateAsync(Guid id, ReceptionistForUpdateDto model)
    {
        if (model == null)
            return null;

        var receptionist = await _receptionistRepository.GetByIdAsync(id);
        if (receptionist == null)
            return null;

        _mapper.Map(model, receptionist);
        await _receptionistRepository.SaveAsync();
        return _mapper.Map<ReceptionistDto>(receptionist);
    }

    public async Task<List<ReceptionistDto>> GetAsync()
    {
        return _mapper.Map<List<ReceptionistDto>>(await _receptionistRepository.GetAllAsync());
    }

    public async Task<ReceptionistDto> GetByIdAsync(Guid id)
    {
        return _mapper.Map<ReceptionistDto>(await _receptionistRepository.GetByIdAsync(id));
    }
}
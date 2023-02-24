using AutoMapper;
using MassTransit;
using Microsoft.Extensions.Configuration;
using ProfilesMicroService.Application.Dto.Doctor;
using ProfilesMicroService.Application.Services.Abstractions;
using ProfilesMicroService.Domain.Entities.Models;
using ProfilesMicroService.Infrastructure.Repository.Abstractions;
using SharedModel;

namespace ProfilesMicroService.Application.Services;

public class DoctorService : IDoctorService
{
    private readonly IDoctorRepository _doctorRepository;
    private readonly IMapper _mapper;
    private readonly ISendEndpoint _endPoint;
    private readonly IStatusRepository _statusRepository;

    public DoctorService(IDoctorRepository doctorRepository, IStatusRepository statusRepository, IMapper mapper, IBus bus, IConfiguration configuration)
    {
        _doctorRepository = doctorRepository;
        _statusRepository = statusRepository;
        _mapper = mapper;
        _endPoint = bus.GetSendEndpoint(new Uri(configuration.GetValue<string>("RabbitMQ:Uri") + configuration.GetValue<string>("RabbitMQ:QueueName:Producer:Profile:Doctor"))).GetAwaiter().GetResult();
    }

    public async Task<DoctorDto> ChangeStatusAsync(Guid id, string status)
    {
        var doctor = await _doctorRepository.GetByIdAsync(id);
        if (doctor == null)
            return null;

        var newStatus = await _statusRepository.GetByNameAsync(status);
        if (newStatus == null)
            return null;

        doctor.StatusId = newStatus.Id;

        await _doctorRepository.SaveAsync();
        return _mapper.Map<DoctorDto>(doctor);
    }

    public async Task<DoctorDto> CreateAsync(DoctorForCreateDto model)
    {
        if (model == null)
            return null;
        var Status = await _statusRepository.GetByNameAsync(model.Status.Name);
        if (Status == null)
            return null;
        var doctorMap = _mapper.Map<Doctor>(model);
        doctorMap.StatusId = Status.Id;
        await _doctorRepository.InsertAsync(doctorMap);
        return _mapper.Map<DoctorDto>(doctorMap);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var doctor = await _doctorRepository.GetByIdAsync(id);

        if (doctor == null)
            return false;

        await _doctorRepository.DeleteAsync(id);
        return true;
    }

    public async Task<DoctorDto> UpdateAsync(Guid id, DoctorForUpdateDto model)
    {
        if (model == null)
            return null;

        var doctor = await _doctorRepository.GetByIdAsync(id);
        if (doctor == null)
            return null;

        _mapper.Map(model, doctor);
        doctor.StatusId = model.Status.Id;
        await _doctorRepository.SaveAsync();
        var message = new DoctorMessage
        {
            Id = id,
            FirstName = model.FirstName,
            LastName = model.LastName,
            MiddleName = model.MiddleName
        };
        await _endPoint.Send(message);
        return _mapper.Map<DoctorDto>(doctor);
    }

    public async Task<List<DoctorDto>> GetAsync()
    {
        var temp = await _doctorRepository.GetAllAsync();
        return _mapper.Map<List<DoctorDto>>(temp);
    }

    public async Task<DoctorDto> GetByIdAsync(Guid id)
    {
        return _mapper.Map<DoctorDto>(await _doctorRepository.GetByIdAsync(id));
    }

    public async Task<List<DoctorDto>> GetDoctorsByStatusAsync(string status)
    {
        return _mapper.Map<List<DoctorDto>>(await _doctorRepository.GetByStatusAsync(status));
    }
}
using AutoMapper;
using MediatR;
using ProfilesMicroService.Application.Dto.Patient;
using ProfilesMicroService.Infrastructure.Repository.Abstractions;

namespace ProfilesMicroService.Application.CQRS.Queries;

public record GetPatientByIdQuery(Guid Id) : IRequest<PatientDto>
{
    public class GetPatientByIdHandler : IRequestHandler<GetPatientByIdQuery, PatientDto>
    {
        private readonly IMapper _mapper;
        private readonly IPatientRepository _repository;

        public GetPatientByIdHandler(IPatientRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PatientDto> Handle(GetPatientByIdQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<PatientDto>(await _repository.GetByIdAsync(request.Id, cancellationToken));
        }
    }
}
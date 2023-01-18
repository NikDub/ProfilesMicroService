using AutoMapper;
using MediatR;
using ProfilesMicroService.Application.Dto.Patient;
using ProfilesMicroService.Infrastructure.Repository.Abstractions;

namespace ProfilesMicroService.Application.CQRS.Queries;

public record GetPatientByAccountIdQuery(string AccountId) : IRequest<PatientDto>
{
    public class GetPatientByAccountIdHandler : IRequestHandler<GetPatientByAccountIdQuery, PatientDto>
    {
        private readonly IMapper _mapper;
        private readonly IPatientRepository _repository;

        public GetPatientByAccountIdHandler(IPatientRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PatientDto> Handle(GetPatientByAccountIdQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<PatientDto>(await _repository.GetByIdAsync(request.AccountId, cancellationToken));
        }
    }
}
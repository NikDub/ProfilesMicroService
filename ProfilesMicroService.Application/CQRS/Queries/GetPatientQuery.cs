using AutoMapper;
using MediatR;
using ProfilesMicroService.Application.Dto.Patient;
using ProfilesMicroService.Infrastructure.Repository.Abstractions;

namespace ProfilesMicroService.Application.CQRS.Queries;

public record GetPatientQuery : IRequest<IEnumerable<PatientDto>>
{
    public class GetPatientHandler : IRequestHandler<GetPatientQuery, IEnumerable<PatientDto>>
    {
        private readonly IMapper _mapper;
        private readonly IPatientRepository _repository;

        public GetPatientHandler(IPatientRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PatientDto>> Handle(GetPatientQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<IEnumerable<PatientDto>>(await _repository.GetAllAsync(cancellationToken));
        }
    }
}
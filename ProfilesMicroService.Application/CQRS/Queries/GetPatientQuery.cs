using AutoMapper;
using MediatR;
using ProfilesMicroService.Application.DTO.Patient;
using ProfilesMicroService.Infrastructure.Repository.Abstractions;

namespace ProfilesMicroService.Application.CQRS.Queries
{
    public record GetPatientQuery() : IRequest<IEnumerable<PatientDTO>>
    {
        public class GetPatientHandler : IRequestHandler<GetPatientQuery, IEnumerable<PatientDTO>>
        {
            private readonly IPatientRepository _repository;
            private readonly IMapper _mapper;

            public GetPatientHandler(IPatientRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<IEnumerable<PatientDTO>> Handle(GetPatientQuery request, CancellationToken cancellationToken) =>
               _mapper.Map<IEnumerable<PatientDTO>>(await _repository.GetAllAsync(cancellationToken));
        }
    }
}

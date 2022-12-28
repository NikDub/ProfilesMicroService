using AutoMapper;
using MediatR;
using ProfilesMicroService.Application.DTO.Patient;
using ProfilesMicroService.Infrastructure.Repository.Abstractions;

namespace ProfilesMicroService.Application.CQRS.Queries
{
    public record GetPatientByIdQuery(string Id) : IRequest<PatientDTO>
    {
        public class GetPatientByIdHandler : IRequestHandler<GetPatientByIdQuery, PatientDTO>
        {
            private readonly IPatientRepository _repository;
            private readonly IMapper _mapper;

            public GetPatientByIdHandler(IPatientRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<PatientDTO> Handle(GetPatientByIdQuery request, CancellationToken cancellationToken) =>
                _mapper.Map<PatientDTO>(await _repository.GetByIdAsync(request.Id, cancellationToken));
        }
    }
}

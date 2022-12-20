using AutoMapper;
using MediatR;
using ProfilesMicroService.Application.DTO.Patient;
using ProfilesMicroService.Application.Services.Abstractions;

namespace ProfilesMicroService.Application.Services.CQRS.Queries
{
    public record GetPatientByAccountIdQuery(string AccountId) : IRequest<PatientDTO>
    {
        public class GetPatientByAccountIdHandler : IRequestHandler<GetPatientByAccountIdQuery, PatientDTO>
        {
            private readonly IPatientRepository _repository;
            private readonly IMapper _mapper;

            public GetPatientByAccountIdHandler(IPatientRepository repository, IMapper mapper)
            {
                _repository = repository;
                this._mapper = mapper;
            }

            public async Task<PatientDTO> Handle(GetPatientByAccountIdQuery request, CancellationToken cancellationToken) =>
                _mapper.Map<PatientDTO>(await _repository.GetByIdAsync(request.AccountId));
        }
    }
}

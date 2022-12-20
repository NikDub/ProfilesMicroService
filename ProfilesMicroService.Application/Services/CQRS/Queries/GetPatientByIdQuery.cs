using AutoMapper;
using MediatR;
using ProfilesMicroService.Application.DTO.Patient;
using ProfilesMicroService.Application.Services.Abstractions;

namespace ProfilesMicroService.Application.Services.CQRS.Queries
{
    public record GetPatientByIdQuery(string id) : IRequest<PatientDTO>
    {
        public class GetPatientByIdHandler : IRequestHandler<GetPatientByIdQuery, PatientDTO>
        {
            private readonly IPatientRepository _repository;
            private readonly IMapper _mapper;

            public GetPatientByIdHandler(IPatientRepository repository, IMapper mapper)
            {
                _repository = repository;
                this._mapper = mapper;
            }

            public async Task<PatientDTO> Handle(GetPatientByIdQuery request, CancellationToken cancellationToken) =>
                _mapper.Map<PatientDTO>(await _repository.GetByIdAsync(request.id));
        }
    }
}

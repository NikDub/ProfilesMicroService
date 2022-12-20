using AutoMapper;
using MediatR;
using ProfilesMicroService.Application.Services.Abstractions;
using ProfilesMicroService.Application.Services.CQRS.Queries;
using ProfilesMicroService.Application.Services.DTO;

namespace ProfilesMicroService.Application.Services.CQRS.Handlers
{
    internal class GetPatientHandler : IRequestHandler<GetPatientQuery, IEnumerable<PatientDTO>>
    {
        private readonly IPatientRepository _repository;
        private readonly IMapper _mapper;

        public GetPatientHandler(IPatientRepository repository, IMapper mapper)
        {
            _repository = repository;
            this._mapper = mapper;
        }

        public async Task<IEnumerable<PatientDTO>> Handle(GetPatientQuery request, CancellationToken cancellationToken) =>
           _mapper.Map<IEnumerable<PatientDTO>>(await _repository.GetAllAsync());
    }
}

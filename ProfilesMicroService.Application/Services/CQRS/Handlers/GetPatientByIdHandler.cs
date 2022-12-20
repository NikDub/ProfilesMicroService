using AutoMapper;
using MediatR;
using ProfilesMicroService.Application.Services.Abstractions;
using ProfilesMicroService.Application.Services.CQRS.Queries;
using ProfilesMicroService.Application.Services.DTO;
using ProfilesMicroService.Domain.Entities.Models;

namespace ProfilesMicroService.Application.Services.CQRS.Handlers
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

        public async Task<PatientDTO> Handle(GetPatientByIdQuery request, CancellationToken cancellationToken)=>
            _mapper.Map<PatientDTO>(await _repository.GetByIdAsync(request.id));
    }
}

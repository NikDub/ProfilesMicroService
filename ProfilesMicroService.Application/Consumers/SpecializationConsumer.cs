using MassTransit;
using ProfilesMicroService.Infrastructure.Repository.Abstractions;
using SharedModel;

namespace ProfilesMicroService.Application.Consumers
{
    public class SpecializationConsumer : IConsumer<SpecializationMessage>
    {
        private readonly IDoctorRepository _doctorRepository;
        public SpecializationConsumer(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public async Task Consume(ConsumeContext<SpecializationMessage> context)
        {
            var message = context.Message;
            await _doctorRepository.UpdateSpecializationNameAsync(message.Id, message.SpecializationName);
        }
    }
}

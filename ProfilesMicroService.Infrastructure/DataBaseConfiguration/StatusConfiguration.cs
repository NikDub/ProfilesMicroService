using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProfilesMicroService.Domain.Entities.Enums;
using ProfilesMicroService.Domain.Entities.Models;

namespace ProfilesMicroService.Api.DataBaseConfiguration
{
    public class StatusConfiguration : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            AddInitialData(builder);
        }

        private void AddInitialData(EntityTypeBuilder<Status> builder)
        {
            builder.HasData
            (
                new Status
                {
                    Id = "242bb89f-149a-4cd0-b81f-55a378b8da3b",
                    Name = StatusEnum.AtWork.ToString()
                },
                new Status
                {
                    Id = "a6dee6ab-4edf-4006-8e2f-b8be6f842b86",
                    Name = StatusEnum.OnVacation.ToString()
                },
                new Status
                {
                    Id = "222ad367-3e96-41ad-b7e1-e6c3b31d408f",
                    Name = StatusEnum.SickDay.ToString()
                },
                new Status
                {
                    Id = "7a55ff1b-2e82-4db5-abfb-046128e395e0",
                    Name = StatusEnum.SickLeave.ToString()
                },
                new Status
                {
                    Id = "b9877be3-1b84-4083-a464-fb2c6dfda87d",
                    Name = StatusEnum.SelfIsolation.ToString()
                },
                new Status
                {
                    Id = "ceb6bc1e-cc2b-43ae-8243-b73fb11a4d0f",
                    Name = StatusEnum.LeaveWithoutPay.ToString()
                },
                new Status
                {
                    Id = "283f6717-6bbf-4b06-b960-2a2a6b727630",
                    Name = StatusEnum.Inactive.ToString()
                }
            );
        }
    }
}

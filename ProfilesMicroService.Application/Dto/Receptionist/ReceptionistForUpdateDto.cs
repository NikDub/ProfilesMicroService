using System.ComponentModel.DataAnnotations;

namespace ProfilesMicroService.Application.Dto.Receptionist;

public class ReceptionistForUpdateDto
{
    public Guid AccountId { get; set; }

    [Required] public string FirstName { get; set; }

    [Required] public string LastName { get; set; }

    public string MiddleName { get; set; }

    [Required] public Guid OfficeId { get; set; }
}
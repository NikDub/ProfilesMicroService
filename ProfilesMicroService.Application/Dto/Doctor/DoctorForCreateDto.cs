using System.ComponentModel.DataAnnotations;

namespace ProfilesMicroService.Application.Dto.Doctor;

public class DoctorForCreateDto
{
    public Guid AccountId { get; set; }

    [Required] public string FirstName { get; set; }

    [Required] public string LastName { get; set; }

    public string MiddleName { get; set; }

    [Required] public DateTime DateOfBirth { get; set; }

    public Guid StatusId { get; set; }

    [Required] public int CareerStartYear { get; set; }

    public string AccountPhoneNumber { get; set; }

    [Required] public Guid SpecializationId { get; set; }

    [Required] public string SpecializationName { get; set; }

    [Required] public Guid OfficeId { get; set; }
}
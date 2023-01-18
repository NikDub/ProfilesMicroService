using System.ComponentModel.DataAnnotations;
using ProfilesMicroService.Domain.Entities.Models;

namespace ProfilesMicroService.Application.Dto.Doctor;

public class DoctorForUpdateDto
{
    public string AccountId { get; set; }

    [Required] public string FirstName { get; set; }

    [Required] public string LastName { get; set; }

    public string MiddleName { get; set; }

    [Required] public DateTime DateOfBirth { get; set; }

    public string StatusId { get; set; }

    [Required] public int CareerStartYear { get; set; }

    public string AccountPhoneNumber { get; set; }

    [Required] public string SpecializationId { get; set; }

    [Required] public string SpecializationName { get; set; }

    [Required] public string OfficeId { get; set; }

    [Required] public Status Status { get; set; }
}
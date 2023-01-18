using System.ComponentModel.DataAnnotations;

namespace ProfilesMicroService.Application.Dto.Patient;

public class PatientForMatchDto
{
    [Required] public string FirstName { get; set; }

    [Required] public string LastName { get; set; }

    public string MiddleName { get; set; }

    [Required] public DateTime DateOfBirth { get; set; }
}
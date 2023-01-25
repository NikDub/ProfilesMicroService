namespace ProfilesMicroService.Domain.Entities.Models;

public class Doctor : BaseProfile
{
    public Guid StatusId { get; set; }
    public DateTime DateOfBirth { get; set; }
    public int CareerStartYear { get; set; }

    public string AccountPhoneNumber { get; set; }
    public Guid SpecializationId { get; set; }
    public string SpecializationName { get; set; }
    public Guid OfficeId { get; set; }

    public Status Status { get; set; }
}
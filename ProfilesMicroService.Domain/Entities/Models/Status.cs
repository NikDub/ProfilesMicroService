namespace ProfilesMicroService.Domain.Entities.Models;

public class Status
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public List<Doctor> Doctors { get; set; }
}
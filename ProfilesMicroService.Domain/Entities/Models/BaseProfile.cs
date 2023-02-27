namespace ProfilesMicroService.Domain.Entities.Models;

public class BaseProfile
{
    public Guid Id { get; set; }
    public Guid AccountId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
}
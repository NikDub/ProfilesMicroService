namespace ProfilesMicroService.Domain.Entities.Models;

public class BaseProfile
{
    public string Id { get; set; }
    public string AccountId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
}
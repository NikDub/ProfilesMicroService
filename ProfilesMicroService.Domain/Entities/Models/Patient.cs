namespace ProfilesMicroService.Domain.Entities.Models
{
    public class Patient : BaseProfile
    {
        public DateTime DateOfBirth { get; set; }
        public string AccountPhoneNumber { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace ProfilesMicroService.Application.Services.DTO
{
    public class PatientForUpdateDTO
    {
        public string AccountId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        public string AccountPhoneNumber { get; set; }
    }
}

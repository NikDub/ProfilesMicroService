using System.ComponentModel.DataAnnotations;

namespace ProfilesMicroService.Application.DTO.Patient
{
    public class PatientForCreateDTO
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

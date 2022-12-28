using System.ComponentModel.DataAnnotations;

namespace ProfilesMicroService.Application.DTO.Receptionist
{
    public class ReceptionistForUpdateDTO
    {
        public string AccountId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        [Required]
        public string OfficeId { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace ProfilesMicroService.Domain.Entities.Models
{
    public class Doctor : BaseProfile
    {
        public string StatusId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int CareerStartYear { get; set; }

        public string AccountPhoneNumber { get; set; }
        public string SpecializationId { get; set; }
        public string SpecializationName { get; set; }
        public string OfficeId { get; set; }

        public Status Status { get; set; }
    }
}

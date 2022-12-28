namespace ProfilesMicroService.Application.DTO.Patient
{
    public class PatientDTO
    {
        public string Id { get; set; }
        public string AccountId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string AccountPhoneNumber { get; set; }
    }
}

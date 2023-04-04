namespace BolsaDeTrabajoAPI.Models.Student
{
    public class StudentRegistrationDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public int FileNumber { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
    }
}

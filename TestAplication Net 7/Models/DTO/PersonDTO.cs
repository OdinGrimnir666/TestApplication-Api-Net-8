namespace TestAplication_Net_7.Models.DTO
{
    public class PersonDTO
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }

        public PersonDTO(string lastName, string firstName)
        {
            LastName = lastName;
            FirstName = firstName;
        }
    }
}

namespace ChatStudents_Sabitov.Models
{
    public class User
    {
        public string? Id { get; set; }
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public string? Surname { get; set; }
        public byte[]? Photo {  get; set; }
        public User(string lastName, string firstName, string surname, byte[] photo)
        {
            LastName = lastName;
            FirstName = firstName;
            Surname = surname;
            Photo = photo;
        }
        public string ToFIO()
        {
            return $"{LastName} {FirstName} {Surname}";
        }
    }
}

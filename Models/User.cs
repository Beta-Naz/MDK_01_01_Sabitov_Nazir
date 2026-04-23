namespace ChatStudents_Sabitov.Models
{
    public class User
    {
        public string? Id { get; set; }
        public string? Lastname { get; set; }
        public string? Firstname { get; set; }
        public string? Surname { get; set; }
        public byte[]? Photo {  get; set; }
        public User(string lastname, string firstname, string surname, byte[] photo)
        {
            Lastname = lastname;
            Firstname = firstname;
            Surname = surname;
            Photo = photo;
        }
        public string ToFIO()
        {
            return $"{Lastname} {Firstname} {Surname}";
        }
    }
}

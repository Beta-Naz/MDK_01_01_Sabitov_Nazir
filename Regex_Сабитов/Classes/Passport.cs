namespace Regex_Сабитов.Classes
{
    public class Passport
    {
        public string PhotoPassport { get; set; } = "pack://application:,,,/Regex_Сабитов;component/Images/Passport.png";
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string Forename { get; set; }
        public string Issued { get; set; }
        public string DateOfIssued { get; set; }
        public string DepartmentCode { get; set; }
        public string SeriesAndNumber {get; set;}
        public string DateOfBirth { get; set; }
        public string PlaceOfBirth { get; set; }
    }
}

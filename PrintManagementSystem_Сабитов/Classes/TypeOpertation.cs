using System.Collections.Generic;

namespace PrintManagementSystem_Сабитов.Classes
{
    public class TypeOpertation
    {
        public int id {  get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public TypeOpertation(int id, string name, string description)
        {
            this.id = id;
            this.name = name;
            this.description = description;
        }
        public static List<TypeOpertation> AllTypeOpertation()
        {
            return new List<TypeOpertation>()
            {
                new TypeOpertation(1, "Печать", ""),
                new TypeOpertation(2, "Копия", ""),
                new TypeOpertation(3, "Сканирование", ""),
                new TypeOpertation(4, "Ризограф", ""),
            };
        }
    }
}

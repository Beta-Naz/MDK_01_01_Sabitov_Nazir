using System.Collections.Generic;

namespace Batlle_Сабитов.Classes.Locations
{
    public class CreateLocations
    {
        public List<string> ActiveMonsters;
        public string NameLocations;
        public string Complexity;
        public string BackgroundLocations;
        public CreateLocations(List<string> activeMonsters, string nameLocations, string complexity , string backgroundLocations)
        {
            ActiveMonsters = activeMonsters;
            NameLocations = nameLocations;
            Complexity = complexity;
            BackgroundLocations = backgroundLocations;
        }
        public static List<string> AllowedLocations = new List<string> { "Замок", "Лощина Последнего Вздоха", ""};
        public static string LastLocation = "";
        public static string LastLocationSourse = "";
    }
}

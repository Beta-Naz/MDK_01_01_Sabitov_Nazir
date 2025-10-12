using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batlle_Сабитов.Classes.Object
{
    //"Cutting", "Stabbing", "Crushing"
    public class RepoWeapon
    {
        public static List<Weapon> AllWeapon = new List<Weapon>()
        {
            new Weapon(140,"pack://application:,,,/Batlle_Сабитов;component/Images/Object/Короткий_меч.png",
                "Короткий меч", false, 1.10, 0.20, 2, 0.90, new List<string>(){"Cutting"}),
            new Weapon(200,"pack://application:,,,/Batlle_Сабитов;component/Images/Object/Меч.png",
                "Меч", false, 1.40, 0.30, 2, 0.50, new List<string>(){"Cutting"}),
           new Weapon(400,"pack://application:,,,/Batlle_Сабитов;component/Images/Object/Парные_двух_метровые_мечи.png",
                "Парные мечи", false, 2, 0.40, 2, 0.80, new List<string>(){"Cutting"}),
           new Weapon(1000,"pack://application:,,,/Batlle_Сабитов;component/Images/Object/Эльфийский_лук.png",
                "Эльфийский лук", false, 3, 0.90, 4, 0, new List<string>(){"Stabbing"}),
        };
    }
}

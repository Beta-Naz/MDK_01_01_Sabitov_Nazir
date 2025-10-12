using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batlle_Сабитов.Classes.Object
{
    public class RepoMedicinalPotions
    {
        public static List<MedicinalPotions> AllMedicinalPotions = new List<MedicinalPotions>()
        {
            new MedicinalPotions(30,"pack://application:,,,/Batlle_Сабитов;component/Images/Object/Малое_зелье_здоровья.png",
                "Малое зелье здоровья", false, 50),
            new MedicinalPotions(55,"pack://application:,,,/Batlle_Сабитов;component/Images/Object/Среднее_зелье_здоровья.png",
                "Среднее зелье здоровья", false, 100),
            new MedicinalPotions(100,"pack://application:,,,/Batlle_Сабитов;component/Images/Object/Большое_зелье_здоровья.png",
                "Большое зелье здоровья", false, 200),
        };
    }
}

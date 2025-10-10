using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batlle_Сабитов.Classes.Object
{
    public class RepoMedicinalPorions
    {
        public static List<MedicinalPotions> MedicinalPotions = new List<MedicinalPotions>()
        {
            new MedicinalPotions(10,"pack://application:,,,/Batlle_Сабитов;component/Images/Object/Малое_зелье_здоровья.png",
                "Малое зелье здоровья", false, 50),
            new MedicinalPotions(10,"pack://application:,,,/Batlle_Сабитов;component/Images/Object/Среднее_зелье_здоровья.png",
                "Среднее зелье здоровья", false, 100),
            new MedicinalPotions(10,"pack://application:,,,/Batlle_Сабитов;component/Images/Object/Большое_зелье_здоровья.png",
                "Большое зелье здоровья", false, 200),
        };
    }
}

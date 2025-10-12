using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Batlle_Сабитов.Classes.Metod
{
    public class Variables
    {
        public static int death;
        public static int[] SelectLocation = new int[] {0,1};
        //"Cutting", "Stabbing", "Crushing"
        public static readonly Dictionary<string, Brush> PowerAndVulnerabilityMonster = new Dictionary<string, Brush>
        {
            ["Easy"] = Brushes.Yellow,
            ["Medium"] = Brushes.Orange,
            ["Hard"] = Brushes.Red,
            ["VeryHard"] = Brushes.DarkRed,
            ["VeryHard"] = Brushes.DarkViolet,
            ["Cutting"] = Brushes.Silver,
            ["Stabbing"] = Brushes.Red,
            ["Crushing"] = Brushes.Brown,
            ["CuttingAndStabbing"] = Brushes.Violet,
            [""] = Brushes.BlueViolet,
        };
        public static readonly Dictionary<string, Brush> Color = new Dictionary<string, Brush>
        {
            ["#FF7FFFD4"] = Brushes.Aquamarine,
            ["#FFFFFF00"] = Brushes.Yellow,
            ["#FFFF0000"] = Brushes.DarkRed,
        };
        public static List<object> ОbjectForInvety = new List<object>();
    }
}

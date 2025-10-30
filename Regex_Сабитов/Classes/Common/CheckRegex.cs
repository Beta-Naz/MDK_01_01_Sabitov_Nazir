using System.Text.RegularExpressions;

namespace Regex_Сабитов.Classes.Common
{
    public class CheckRegex
    {
        public static bool Match(string pattern, string input)
        {
            Match m = Regex.Match(input, pattern);
            return m.Success;
        }
    }
}

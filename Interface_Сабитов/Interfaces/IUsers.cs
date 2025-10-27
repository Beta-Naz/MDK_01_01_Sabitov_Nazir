using Interface_Сабитов.Models;
using System.Collections.Generic;

namespace Interface_Сабитов.Interfaces
{
    public interface IUsers
    {
        void All(out List<Users> Users);
    }
}

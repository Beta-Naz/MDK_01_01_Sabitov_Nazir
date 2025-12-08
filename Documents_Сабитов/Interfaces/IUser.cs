using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Documents_Сабитов.Interfaces
{
    public interface IUser
    {
        void Save(bool update = false);
        List<Model.User> AllUser();
        void Delete();
    }
}

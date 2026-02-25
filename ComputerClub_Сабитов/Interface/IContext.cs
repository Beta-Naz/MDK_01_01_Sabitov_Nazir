using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerClub_Сабитов.Interface
{
    public interface IContext
    {
        List<object> GetAll();
        void Save(bool update = false);
        void Delete();
    }
}

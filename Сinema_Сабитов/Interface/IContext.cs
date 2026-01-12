using System.Collections.Generic;

namespace Сinema_Сабитов.Interface
{
    public interface IContext
    {
        List<object> All();
        void Save(bool Update = false);
        void Delete();
    }
}

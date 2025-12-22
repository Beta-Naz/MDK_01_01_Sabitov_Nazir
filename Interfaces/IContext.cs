using System.Collections.Generic;

namespace Shop_Сабитов.Interfaces
{
    public interface IContext
    {
        List<object> All();
        void Save(bool Update = false);
        void Delete();
    }
}
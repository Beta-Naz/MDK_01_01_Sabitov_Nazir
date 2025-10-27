using System;
using System.Collections.Generic;

namespace Interface_Сабитов.Interfaces
{
    public interface IMessages
    {
        void All(out List<IMessages> Messages);
        void Save (bool Update = false);
        void Delete();
    }
}

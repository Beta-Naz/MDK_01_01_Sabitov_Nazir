using System.Collections.Generic;
namespace Documents_Сабитов.Interfaces
{
    public interface IDocument
    {
        void Save(bool update = false);
        List<Model.Document> AllDocument();
        void Delete();
    }
}

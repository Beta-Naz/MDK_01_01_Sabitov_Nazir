using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Documents_Сабитов.Classes.Common;
using Documents_Сабитов.Interfaces;
using Documents_Сабитов.Model;

namespace Documents_Сабитов.Classes
{
    public class DocumentContext : Model.DocumentContext, IDocument
    {
        public List<Model.DocumentContext> AllDocument()
        {
            List<Model.DocumentContext> allDocument = new List<Model.DocumentContext>();
            OleDbConnection connection = DBConnection.Connection();
            OleDbDataReader dataDocuments = DBConnection.Query("SELECT * FROM [Документы]", connection);
            while (dataDocuments.Read())
            {
                allDocument.Add(new DocumentContext()
                { 
                    Id = dataDocuments.GetInt32(0),
                    Src = dataDocuments.GetString(1),
                    Name = dataDocuments.GetString(2),
                    User = dataDocuments.GetString(3),
                    IdDocument = dataDocuments.GetInt32(4),
                    Date = dataDocuments.GetDateTime(5),
                    Status = dataDocuments.GetInt32(6),
                    Direction = dataDocuments.GetInt32(7),
                });
            }
            DBConnection.CloseConnection(connection);
            return allDocument;
        }

        public void Delete()
        {
            OleDbConnection connection = Common.DBConnection.Connection();
            Common.DBConnection.Query($"DELETE FROM [Документы] WHERE [Код] = {this.Id}", connection);
            Common.DBConnection.CloseConnection(connection);
        }

        public void Save(bool update = false)
        {
            OleDbConnection connection = DBConnection.Connection();
            if (update)
            {
                DBConnection.Query(
                    $"UPDATE " +
                        $"[Документы] " +
                    $"SET " +
                        $"[Изображение] = '{this.Src}', " +
                        $"[Наименование] = '{this.Name}', " +
                        $"[Ответственный] = '{this.User}', " +
                        $"[Код документа] = '{this.IdDocument}', " +
                        $"[Дата поступления] = '{this.Date.ToString("dd.MM.yyyy")}', " +
                        $"[Статус] = '{this.Status}', " +
                        $"[Направление] = '{this.Direction}', " +
                    $"WHERE " +
                        $"[Код]= {this.Id}", connection);
            }
            else
            {
                DBConnection.Query(
                        $"INSERT INTO " +
                         $"[Документы](" +
                             $"[Изображение], " +
                             $"[Наименование], " +
                             $"[Ответственный], " + 
                             $"[Код документа], " +
                             $"[Дата поступления], " +
                             $"[Статус], [Направление]) " +
                        $"VALUES " +
                           $"('{this.Src}', " +
                           $"'{this.Name}', " +
                           $"'{this.User}', " +
                           $"'{this.IdDocument}', " +
                           $"'{this.Date.ToString("dd.MM.yyyy")}', " +
                           $"'{this.Status}', " +
                           $"'{this.Direction}',)", connection);
            }
        }
    }
}

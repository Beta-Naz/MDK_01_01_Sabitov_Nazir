using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Documents_Сабитов.Classes;

namespace Documents_Сабитов.Elements
{
    /// <summary>
    /// Логика взаимодействия для Item.xaml
    /// </summary>
    public partial class Item : UserControl
    {
        DocumentContext Document;
        public Item(DocumentContext documentContext)
        {
            InitializeComponent();

            img.Source = new BitmapImage(new Uri(documentContext.Src));
            lName.Content = documentContext.Name;
            lUser.Content = "Ответственный: " + documentContext.User;
            lCode.Content = "Код документа: " + documentContext.IdDocument;
            lDate.Content = "Дата поступления: " + documentContext.Date.ToString("dd.MM.yyyy");
            lStatus.Content = documentContext.Status == 0 ? "Статус: входящий" : "Статус: исходящий";
            lDirection.Content = "Направление: " + documentContext.Direction;

            Document = documentContext;
        }

        private void EditDocument(object sender, RoutedEventArgs e)
        {
            MainWindow.init.frame.Navigate(new Pages.Add(Document));
        }

        private void DeleteDocument(object sender, RoutedEventArgs e)
        {
            Document.Delete();
            MainWindow.init.AllDocuments = new DocumentContext().AllDocument();
            MainWindow.init.frame.Navigate(new Pages.Main());
        }
    }
}

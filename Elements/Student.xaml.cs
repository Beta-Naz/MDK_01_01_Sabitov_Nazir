using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Constructors_Сабитов.Elements
{
    /// <summary>
    /// Логика взаимодействия для Student.xaml
    /// </summary>
    public partial class Student : UserControl
    {
        public Student(Classes.Student student)
        {
            InitializeComponent();

            td_fio.Content = student.GetFIO();

            td_scholarship.Content = student.Scholarship ? "Степендия: получает" : "Степендия: не получает";

            td_course.Content = $"Курс: {student.Course}";

            img.Source = new BitmapImage(new Uri(student.Src));
        }
    }
}

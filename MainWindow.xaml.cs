using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Overload_Сабитов.Classes;

namespace Overload_Сабитов
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Student> students = Classes.RepoStudents.AllStudents();
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Tab.Items.Clear();
            var student = students.Select(c => c.GetFIO(Separator.Text));
            if (Separator.Text == "" || Separator.Text == null || Separator.Text.Length == 2)
            {
                student = students.Select(c => c.GetFIO());
            }
            foreach (var stud in student)
            {
                Tab.Items.Add(stud);
            }
        }
    }
}

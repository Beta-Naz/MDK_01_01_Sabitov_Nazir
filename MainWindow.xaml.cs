using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Constructors_Сабитов
{
    public partial class MainWindow : Window
    {
        private List<Classes.Student> _allStudentsOriginal = Classes.RepoStudents.AllStudents();

        public List<Classes.Student> AllStudent;

        public int Count = 10;
        public int Step = 0;

        public MainWindow()
        {
            InitializeComponent();

            AllStudent = new List<Classes.Student>(_allStudentsOriginal);

            CreateStudent(Step, Count);
        }

        public void CreateStudent(int Step, int Count)
        {
            for (int iStudent = Step; iStudent < Step + Count; iStudent++)
            {
                if (AllStudent.Count > iStudent)
                {
                    parent.Children.Add(new Elements.Student(AllStudent[iStudent]));
                }
            }
            this.Step += Count;
        }

        private void ScrollViewer_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            ScrollViewer scroll = sender as ScrollViewer;
            double ParentHeight = parent.ActualHeight;
            double WindowHeight = scroll.ActualHeight - 20;
            double DeltaHeight = ParentHeight - WindowHeight;

            if (DeltaHeight - scroll.VerticalOffset < 140)
            {
                CreateStudent(Step, Count);
            }
        }

        private void Sort(object sender, RoutedEventArgs e)
        {
            AllStudent = AllStudent.OrderBy(x => x.Lastname)
                .ThenBy(x => x.Firstname)
                .ThenBy(x => x.Surname)
                .ToList();
            UpdateDisplay();
        }

        private void NoSort(object sender, RoutedEventArgs e)
        {
            AllStudent = new List<Classes.Student>(_allStudentsOriginal);
            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            parent.Children.Clear();
            Step = 0;
            CreateStudent(Step, Count);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox searchBox = sender as TextBox;
            string searchText = searchBox?.Text?.Trim().ToLower() ?? "";

            if (string.IsNullOrEmpty(searchText))
            {
                AllStudent = new List<Classes.Student>(_allStudentsOriginal);
            }
            else
            {
                AllStudent = _allStudentsOriginal
                    .Where(student =>
                        (!string.IsNullOrEmpty(student.Lastname) &&
                         student.Lastname.ToLower().Contains(searchText)) ||
                        (!string.IsNullOrEmpty(student.Firstname) &&
                         student.Firstname.ToLower().Contains(searchText)) ||
                        (!string.IsNullOrEmpty(student.Surname) &&
                         student.Surname.ToLower().Contains(searchText)))
                    .ToList();
            }
            UpdateDisplay();
        }
    }
}
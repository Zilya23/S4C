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
using Core.Function;
using Core.DataBase;

namespace School4Children.Pages
{
    /// <summary>
    /// Логика взаимодействия для RedactionCirclePage.xaml
    /// </summary>
    public partial class RedactionCirclePage : Page
    {
        public Lesson redLesson { get; set; }
        public List<Teacher> teachers { get; set; }
        public RedactionCirclePage(Lesson lesson)
        {
            InitializeComponent();
            redLesson = lesson;
            teachers = TeacherFunction.GetTeachers();
            cbTeacher.ItemsSource = teachers;
            cbTeacher.SelectedItem = lesson.Teacher;
            tbName.Text = lesson.Name;
            DataContext = this;
        }

        private void btnBackClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new HeadTimtableMainPage());
        }

        private void btnSaveClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (tbName.Text.Trim().Length != 0)
                {
                    redLesson.Name = tbName.Text.Trim();

                    if (cbTeacher.SelectedItem != null)
                    {
                        redLesson.Teacher = cbTeacher.SelectedItem as Teacher;
                        LessonFunction.SaveChangesLesson(redLesson);
                        MessageBox.Show("Успешно!");
                        NavigationService.Navigate(new HeadTimtableMainPage());
                    }
                    else
                    {
                        MessageBox.Show("Заполните все поля!");
                    }
                }
                else
                {
                    MessageBox.Show("Заполните все поля!");
                }
            }
            catch
            {
                MessageBox.Show("Проверьте все поля!");
            }
        }

        private void btnDeleteClick(object sender, RoutedEventArgs e)
        {
            var messageDelete = MessageBox.Show("Вы действительно хотите удалить кружок?", "Внимание", MessageBoxButton.YesNoCancel);
            if (messageDelete == MessageBoxResult.Yes)
            {
                redLesson.IsDelete = true;
                LessonFunction.SaveChangesLesson(redLesson);
                MessageBox.Show("Успешно!");
                NavigationService.Navigate(new HeadTimtableMainPage());
            }
        }
    }
}

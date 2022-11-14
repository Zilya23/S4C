using Core.DataBase;
using Core.Function;
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

namespace School4Children.Pages
{
    public partial class TeacherLessonsTimePage : Page
    {
        Lesson lesson = new Lesson();

        Teacher teacher = new Teacher();
        public List<TimeLesson> lessonsList { get; set; }
        public TeacherLessonsTimePage(Lesson l, Teacher teacher1)
        {
            InitializeComponent();
            lesson = l;
            teacher = teacher1;
            tb_lesson.Text = lesson.Name;

            lessonsList = new List<TimeLesson>();
            lessonsList = TimeLessonFunction.GetTimeLesson().Where(t => t.IDLesson == lesson.ID && t.Lesson.IDTeacher == teacher.ID).ToList();

            DataContext = this;

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TeacherTimeTablePage(teacher));
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddTimeLessonPage(teacher, lesson));
        }

        private void lvTimetable_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var a = lvTimetable.SelectedItem as TimeLesson;
            if (a.DateLesson == DateTime.Today)
                NavigationService.Navigate(new UpdateTeacherTimeLessonPage(teacher, lesson, a));
            else
                MessageBox.Show("Нельзя редактировать прошлые дни", "error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}

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
    /// <summary>
    /// Логика взаимодействия для TeacherTimeTablePage.xaml
    /// </summary>
    public partial class TeacherTimeTablePage : Page
    {
        Teacher teacher = new Teacher();
        public List<GroupTime> groupList { get; set; }
        public List<Lesson> lessonList { get; set; }
        public TeacherTimeTablePage(Teacher teacher1)
        {
            InitializeComponent();
            teacher = teacher1;

            groupList = new List<GroupTime>();
            groupList = GroupTimeFunction.GetGroupTime().Where(a => a.GroupStatistic.Lesson.IDTeacher == teacher.ID).ToList();

            lessonList = new List<Lesson>();
            lessonList = LessonFunction.GetLessons().Where(a => a.IDTeacher == teacher.ID).ToList();
            DataContext = this;
        }

        private void lvTimetable_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var a = lvTimetable.SelectedItem as Lesson;
            NavigationService.Navigate(new TeacherLessonsTimePage(a, teacher));
        }
    }
}

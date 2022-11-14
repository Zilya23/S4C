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
    public partial class UpdateTeacherTimeLessonPage : Page
    {
        Teacher teacher = new Teacher();

        Lesson lesson = new Lesson();

        TimeLesson time = new TimeLesson();

        Timetable timet = new Timetable();

        GroupTime groupTime = new GroupTime();
        public List<GroupStatistic> groupList { get; set; }

        public List<GroupTime> groupTimeList { get; set; }
        public UpdateTeacherTimeLessonPage(Teacher t, Lesson l, TimeLesson tl)
        {
            InitializeComponent();

            teacher = t;
            lesson = l;
            time = tl;

            data_dp.SelectedDate = time.DateLesson;
            tp_time.Text = time.TimeLessons.ToString();
            tbx_classroom.Text = time.Classroom;

            groupList = new List<GroupStatistic>();
            groupList = GroupStudentFunction.GetGroupStatistic().Where(a => a.IDLesson == lesson.ID && a.Lesson.IDTeacher == teacher.ID).ToList();

            groupTimeList = BDConnection.connection.GroupTime.Where(x => x.GroupStatistic.IDLesson == lesson.ID && x.Timetable.TimeLesson.ID == time.ID).ToList();
            DataContext = this;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TeacherLessonsTimePage(lesson, teacher));
        }




        private void cbx_this_Click(object sender, RoutedEventArgs e)
        {
            BDConnection.connection.SaveChanges();
        }
    }
}

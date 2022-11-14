using Core.DataBase;
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
using static System.Net.Mime.MediaTypeNames;

namespace School4Children.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddTimeLessonPage.xaml
    /// </summary>
    public partial class AddTimeLessonPage : Page
    {
        Teacher teacher = new Teacher();

        Lesson lesson = new Lesson();

        TimeLesson time = new TimeLesson();

        Timetable timet = new Timetable();

        GroupTime groupTime = new GroupTime();
        public List<GroupStatistic> groupList { get; set; }

        public List<GroupTime> groupTimeList { get; set; }  
        public AddTimeLessonPage(Teacher t, Lesson l)
        {
            InitializeComponent();

            teacher = t;
            lesson = l;

            data_dp.BlackoutDates.AddDatesInPast();
            data_dp.DisplayDateEnd = DateTime.Now;

            groupList = new List<GroupStatistic>();
            groupList = GroupStudentFunction.GetGroupStatistic().Where(a => a.IDLesson == lesson.ID && a.Lesson.IDTeacher == teacher.ID).ToList();

            groupTimeList = BDConnection.connection.GroupTime.Where(x => x.GroupStatistic.IDLesson == lesson.ID ).ToList();
            DataContext = this;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TeacherLessonsTimePage(lesson, teacher));
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            TimeSpan dtime = TimeSpan.Parse(tp_time.Text);

            var a = data_dp.SelectedDate;
            if (IsDataCorrect(dtime.ToString()) && a != null && tbx_classroom.Text != "")
            {
                time.DateLesson = data_dp.SelectedDate;

                time.TimeLessons = dtime;
                time.IDLesson = lesson.ID;
                time.Classroom = tbx_classroom.Text;

                TimeLessonFunction.SaveLesson(time);

                timet.IsDelete = false;
                timet.IDTimeLesson = time.ID;

                TimeTableFunction.SaveTimetable(timet);



                foreach (var i in groupList)
                {
                    GroupTime group = new GroupTime();
                    group.IDGroup = i.ID;
                    group.IDTimetable = timet.ID;
                    //group.IsVisited = false;
                    BDConnection.connection.GroupTime.Add(group);
                    BDConnection.connection.SaveChanges();
                }

                groupTimeList = BDConnection.connection.GroupTime.Where(x => x.GroupStatistic.IDLesson == lesson.ID && x.IDTimetable == timet.ID).ToList();
                lvTimetable.ItemsSource = groupTimeList;
                lvTimetable.Items.Refresh();
                lvTimetable.Visibility = Visibility.Visible;
                btnSave.Visibility = Visibility.Hidden;
                data_dp.IsEnabled = false;
                tp_time.IsEnabled = false;
                tbx_classroom.IsEnabled = false;
            }
        }

        
        private void cbx_this_Click(object sender, RoutedEventArgs e)
        {
            BDConnection.connection.SaveChanges();
        }

        public bool IsDataCorrect(string datatime)
        {
            var timedate = TimeLessonFunction.GetTimeLesson();
            bool data = true;
            foreach (var a in timedate)
            {
                if (a.TimeLessons.ToString() == datatime && a.DateLesson == DateTime.Today)
                    data = false;
            }
            if (data)
            {
                btnSave.Visibility = Visibility.Visible;
                return true;
            }
            else
            {
                MessageBox.Show("Такая дата уже занята", "error", MessageBoxButton.OK, MessageBoxImage.Error);
                btnSave.Visibility = Visibility.Hidden;
                return false;

            }
        }

        private void tp_time_SelectedTimeChanged(object sender, RoutedPropertyChangedEventArgs<DateTime?> e)
        {
            btnSave.Visibility = Visibility.Visible;
        }
    }
}

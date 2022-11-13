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
    /// Логика взаимодействия для StatisticPage.xaml
    /// </summary>
    public partial class StatisticPage : Page
    {
        public List<GroupTime> groupList { get; set; }
        public StatisticPage()
        {
            InitializeComponent();
            groupList = GroupFunctions.GetGroups();
            DataContext = this;
        }

        private void btnBackClick(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
        private void dpDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dpDate.SelectedDate != null)
            {
                var selectedDate = dpDate.SelectedDate;
                lvLessons.ItemsSource = groupList.Where(x => x.Timetable.TimeLesson.DateLesson == selectedDate).ToList();
            }
        }

        private void tbCircle_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (dpDate.SelectedDate != null)
            {
                var selectedDate = dpDate.SelectedDate;
                lvLessons.ItemsSource = groupList.Where(x => x.Timetable.TimeLesson.Lesson.Name.Contains(tbCircle.Text.ToString())).ToList();
            }
        }

        private void lvLessons_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var item = (sender as ListView).SelectedItem as GroupTime;
                var date = item.Timetable.TimeLesson.DateLesson;
                var time = item.Timetable.TimeLesson.TimeLessons;
                NavigationService.Navigate(new StudentsPage(item.GroupStatistic.Lesson.Teacher.Name + " " + item.GroupStatistic.Lesson.Teacher.LastName + " " + item.GroupStatistic.Lesson.Teacher.Patronic, item.Timetable.TimeLesson.Lesson.Name, (DateTime)date, (TimeSpan)time));

            }
            catch (Exception exc)
            {

            }
        }
    }
}

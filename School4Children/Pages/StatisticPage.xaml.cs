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
    public partial class StatisticPage : Page
    {
        public List<Timetable> groupList { get; set; }
        public StatisticPage()
        {
            InitializeComponent();
            groupList = GroupFunctions.GetTimes();
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
                lvLessons.ItemsSource = groupList.Where(x => x.TimeLesson.DateLesson == selectedDate).ToList();
            }
        }

        private void tbCircle_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbCircle.Text != "")
            {
                var selectedDate = dpDate.SelectedDate;
                lvLessons.ItemsSource = groupList.Where(x => x.TimeLesson.Lesson.Name.Contains(tbCircle.Text.ToString())).ToList();
            }
        }

        private void lvLessons_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var item = (sender as ListView).SelectedItem as Timetable;
            var date = item.TimeLesson.DateLesson;
            var time = item.TimeLesson.TimeLessons;
            NavigationService.Navigate(new StudentsPage(item.TimeLesson.Lesson.Teacher.Name + " " + item.TimeLesson.Lesson.Teacher.LastName + " " + item.TimeLesson.Lesson.Teacher.Patronic, item.TimeLesson.Lesson, (DateTime)date, (TimeSpan)time));

        }
    }
}

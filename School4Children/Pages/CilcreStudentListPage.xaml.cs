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
using Core.DataBase;

namespace School4Children.Pages
{
    /// <summary>
    /// Логика взаимодействия для CilcreStudentListPage.xaml
    /// </summary>
    public partial class CilcreStudentListPage : Page
    {
        public List<GroupStatistic> statisticList { get; set; }
        Teacher teacher = new Teacher();
        GroupStatistic statistic = new GroupStatistic();
        public CilcreStudentListPage(Teacher teacher1)
        {
            InitializeComponent();
            teacher = teacher1;
            statisticList = new List<GroupStatistic>();
            statisticList = BDConnection.connection.GroupStatistic.Where(i => (i.isDelete == false || i.isDelete == null) && (i.Lesson.IDTeacher == teacher.ID)).ToList();

            DataContext = this;
        }

        private void addNewStudentBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RecordStudengtPage(teacher, statistic));
        }

        private void lvTimetable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvTimetable.SelectedItem != null)
            {
                var result = MessageBox.Show("Вы хотите удaлить ученика?", "Delete", MessageBoxButton.YesNo);

                if (result == MessageBoxResult.Yes)
                {
                    var s = lvTimetable.SelectedItem as GroupStatistic;
                    s.isDelete = true;
                    BDConnection.connection.SaveChanges();

                    lvTimetable.ItemsSource = BDConnection.connection.GroupStatistic.Where(i => (i.isDelete != true) && (i.Lesson.IDTeacher == teacher.ID)).ToList();
                }
            }
        }

        private void btnTeacher_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

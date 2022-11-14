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
    /// Логика взаимодействия для RecordStudengtPage.xaml
    /// </summary>
    public partial class RecordStudengtPage : Page
    {
        Teacher teacher = new Teacher();
        GroupStatistic statistic = new GroupStatistic();
        public RecordStudengtPage(Teacher teacher1, GroupStatistic statistic1)
        {
            InitializeComponent();
            statistic = statistic1;
            teacher = teacher1;
            cbCircle.ItemsSource = BDConnection.connection.Lesson.Where(i => (i.IsDelete == false) && (i.IDTeacher == teacher.ID)).ToList();
            cbCircle.SelectedItem = statistic1.Lesson;
            //cbCircle.DisplayMemberPath = "Name";

            cbStudent.ItemsSource = BDConnection.connection.Student.Where(i => i.IsDelete == false).ToList();
            cbStudent.SelectedItem = statistic1.Student;
            DataContext = this;
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            GroupStatistic g = new GroupStatistic();
            
            g.IDStudent = (cbStudent.SelectedItem as Student).ID;
            g.IDLesson = (cbCircle.SelectedItem as Lesson).ID;
            var uniqStud = BDConnection.connection.GroupStatistic.FirstOrDefault(i => i.IDStudent == g.IDStudent && i.IDLesson == g.IDLesson && i.IsDelete != true);
            if (uniqStud == null)
            {
                BDConnection.connection.GroupStatistic.Add(g);
                BDConnection.connection.SaveChanges();
                NavigationService.Navigate(new CilcreStudentListPage(teacher));
            }
            else
                MessageBox.Show("ученик уже записан на этот кружок");
            
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}

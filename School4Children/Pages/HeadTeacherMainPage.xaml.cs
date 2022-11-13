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
using Core.Function;

namespace School4Children.Pages
{
    /// <summary>
    /// Логика взаимодействия для HeadTeacherMainPage.xaml
    /// </summary>
    public partial class HeadTeacherMainPage : Page
    {
        public List<Teacher> teachersList { get; set; }

        public HeadTeacherMainPage()
        {
            InitializeComponent();
            teachersList = new List<Teacher>();
            teachersList = TeacherFunction.GetTeachers();
            DataContext = this;
        }

        private void lvTeacherSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(lvTeacher.SelectedItem != null)
            {
                var teacher = lvTeacher.SelectedItem as Teacher;
                NavigationService.Navigate(new RedTeacherPage(teacher));
            }
        }

        private void btnStatisticClick(object sender, RoutedEventArgs e)
        {

        }

        private void btnTableClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new HeadTimtableMainPage());
        }

        private void btnAddTeacherClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddTeacherPage());
        }
    }
}

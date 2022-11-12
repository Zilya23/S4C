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
    /// Логика взаимодействия для HeadTimtableMainPage.xaml
    /// </summary>
    public partial class HeadTimtableMainPage : Page
    {
        public List<Lesson> lessonsList { get; set; }
        public HeadTimtableMainPage()
        {
            InitializeComponent();
            lessonsList = new List<Lesson>();
            lessonsList = LessonFunction.GetLessons();
            DataContext = this;
        }

        private void btnTeacherClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new HeadTeacherMainPage());
        }

        private void btnStatisticClick(object sender, RoutedEventArgs e)
        {

        }

        private void btnAddLessonClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddCirclePage());
        }
    }
}

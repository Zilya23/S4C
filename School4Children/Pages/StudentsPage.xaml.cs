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

namespace School4Children.Pages
{
    public partial class StudentsPage : Page
    {
        public List<Student> students { get; set; }
        public StudentsPage(string teacherName, string lessonName, DateTime dateTime, TimeSpan time)
        {
            InitializeComponent();
            teacherNameTb.Text = teacherName;
            lessomNameTb.Text = lessonName;
            dateTb.Text = dateTime.ToString("MMMM dd, yyyy") + " " + time.Hours + ":" + time.Minutes;


            DataContext = this;
        }

        private void btnBackClick(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}

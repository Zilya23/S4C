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
    /// <summary>
    /// Логика взаимодействия для TeacherTimeTablePage.xaml
    /// </summary>
    public partial class TeacherTimeTablePage : Page
    {
        Teacher teacher = new Teacher();
        
        public TeacherTimeTablePage(Teacher teacher1)
        {
            InitializeComponent();
            teacher = teacher1;    
        }

        private void btnTeacher_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CilcreStudentListPage(teacher));
        }
    }
}

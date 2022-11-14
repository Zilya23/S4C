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
    /// Логика взаимодействия для RedTeacherPage.xaml
    /// </summary>
    public partial class RedTeacherPage : Page
    {
        public Teacher redTeacher { get; set; }
        public RedTeacherPage(Teacher teacher)
        {
            redTeacher = new Teacher();
            redTeacher = teacher;
            InitializeComponent();
            cbEduation.ItemsSource = EducationFunction.GetEducations();
            cbEduation.DisplayMemberPath = "Name";
            cbEduation.SelectedItem = teacher.Education;

            dpBirthDate.DisplayDateStart = DateTime.Today;
            dpBirthDate.DisplayDateEnd = DateTime.Today.AddYears(-21);

            DataContext = this;
        }

        private void btnSaveClick(object sender, RoutedEventArgs e)
        {
            try
            {
                bool allWrite = true;
                if (tbName.Text.Trim().Length != 0)
                {
                    redTeacher.Name = tbName.Text.Trim();
                }
                else
                    allWrite = false;

                if (tbLastName.Text.Trim().Length != 0)
                {
                    redTeacher.LastName = tbLastName.Text.Trim();
                }
                else
                    allWrite = false;

                if (tbPatronic.Text.Trim().Length != 0)
                {
                    redTeacher.Patronic = tbPatronic.Text.Trim();
                }
                else
                    allWrite = false;

                if (tbPassword.Text.Trim().Length != 0)
                {
                    redTeacher.Password = tbPassword.Text.Trim();
                }
                else
                    allWrite = false;

                if (cbEduation.SelectedItem != null)
                {
                    redTeacher.IDEducation = (cbEduation.SelectedItem as Education).ID;
                }
                else
                    allWrite = false;

                if (dpBirthDate.SelectedDate != null)
                {
                    redTeacher.BirthDate = (DateTime)dpBirthDate.SelectedDate;
                }
                else
                    allWrite = false;

                if (allWrite)
                {
                    TeacherFunction.SaveChangesTeacher(redTeacher);
                    MessageBox.Show("Успешно!");
                    NavigationService.Navigate(new HeadTeacherMainPage());
                }
                else
                {
                    MessageBox.Show("Заполните все поля");
                }

            }
            catch
            {
                MessageBox.Show("Заполните все поля");
            }
        }

        private void btnBackClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new HeadTimtableMainPage());
        }

        private void btnDeleteClick(object sender, RoutedEventArgs e)
        {
            var messageDelete = MessageBox.Show("Вы действительно хотите удалить учителя?", "Внимание", MessageBoxButton.YesNoCancel);
            if (messageDelete == MessageBoxResult.Yes)
            {
                redTeacher.IsDelete = true;
                TeacherFunction.SaveChangesTeacher(redTeacher);
                MessageBox.Show("Успешно!");
                NavigationService.Navigate(new HeadTeacherMainPage());
            }
        }
    }
}

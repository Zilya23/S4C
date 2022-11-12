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
    /// Логика взаимодействия для AddTeacherPage.xaml
    /// </summary>
    public partial class AddTeacherPage : Page
    {
        public AddTeacherPage()
        {
            InitializeComponent();
            cbEduation.ItemsSource = EducationFunction.GetEducations();
            cbEduation.DisplayMemberPath = "Name";

            dpBirthDate.DisplayDateStart = DateTime.Today.AddYears(-80);
            dpBirthDate.DisplayDateEnd = DateTime.Today.AddYears(-21);

            DataContext = this;
        }

        private void btnBackClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new HeadTeacherMainPage());
        }

        private void btnSaveClick(object sender, RoutedEventArgs e)
        {
            try
            {
                Teacher teacher = new Teacher();
                bool allWrite = true;
                if (tbName.Text.Trim().Length != 0)
                {
                    teacher.Name = tbName.Text.Trim();
                }
                else
                    allWrite = false;

                if (tbLastName.Text.Trim().Length != 0)
                {
                    teacher.LastName = tbLastName.Text.Trim();
                }
                else
                    allWrite = false;

                if (tbPatronic.Text.Trim().Length != 0)
                {
                    teacher.Patronic = tbPatronic.Text.Trim();
                }
                else
                    allWrite = false;

                if (tbLogin.Text.Trim().Length != 0)
                {
                    teacher.Login = tbLogin.Text.Trim();
                }
                else
                    allWrite = false;

                if (tbPassword.Text.Trim().Length != 0)
                {
                    teacher.Password = tbPassword.Text.Trim();
                }
                else
                    allWrite = false;

                if (cbEduation.SelectedItem != null)
                {
                    teacher.IDEducation = (cbEduation.SelectedItem as Education).ID;
                }
                else
                    allWrite = false;

                if (dpBirthDate.SelectedDate != null)
                {
                    teacher.BirthDate = (DateTime)dpBirthDate.SelectedDate;
                }
                else
                    allWrite = false;

                teacher.IDRole = 1;
                teacher.IsDelete = false;
                if(allWrite)
                {
                    bool saveTeacher = TeacherFunction.SaveTeacher(teacher);
                    if (saveTeacher)
                    {
                        MessageBox.Show("Успешно!");
                        NavigationService.Navigate(new HeadTeacherMainPage());
                    }
                    else
                    {
                        MessageBox.Show("Введите другой логин!");
                    }
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
    }
}

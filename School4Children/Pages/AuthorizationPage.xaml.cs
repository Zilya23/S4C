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
using Core.Function;
using Core.DataBase;

namespace School4Children.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public AuthorizationPage()
        {
            InitializeComponent();
        }

        private void btnAuthorizClick(object sender, RoutedEventArgs e)
        {
            try
            {
                string login = tbLogin.Text.Trim();
                string password = pbPassword.Password.Trim();
                if(login.Length != 0 && password.Length != 0)
                {
                    Teacher teacher = AuthorizationFunction.Authorization(login, password);
                    if(teacher != null)
                    {
                        if(teacher.IDRole == 1)
                        {
                            NavigationService.Navigate(new HeadTeacherMainPage());
                        }
                        else
                        {
                            NavigationService.Navigate(new TeacherTimeTablePage(teacher));
                        }
                    }
                    else
                    {
                        MessageBox.Show("Неверный логин или пароль!");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Заполните все поля");
            }
        }
    }
}

﻿using System;
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
    /// Логика взаимодействия для RedactionCirclePage.xaml
    /// </summary>
    public partial class RedactionCirclePage : Page
    {
        public RedactionCirclePage()
        {
            InitializeComponent();
        }

        private void btnBackClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new HeadTimtableMainPage());
        }

        private void btnSaveClick(object sender, RoutedEventArgs e)
        {
            try
            {
                Lesson lesson = new Lesson();
                if (tbName.Text.Trim().Length != 0)
                {
                    lesson.Name = tbName.Text.Trim();

                    if (cbTeacher.SelectedItem != null)
                    {
                        lesson.Teacher = cbTeacher.SelectedItem as Teacher;
                        LessonFunction.SaveChangesLesson(lesson);
                        MessageBox.Show("Успешно!");
                        NavigationService.Navigate(new HeadTimtableMainPage());
                    }
                    else
                    {
                        MessageBox.Show("Заполните все поля!");
                    }
                }
                else
                {
                    MessageBox.Show("Заполните все поля!");
                }
            }
            catch
            {
                MessageBox.Show("Проверьте все поля!");
            }
        }

        private void btnDeleteClick(object sender, RoutedEventArgs e)
        {

        }
    }
}

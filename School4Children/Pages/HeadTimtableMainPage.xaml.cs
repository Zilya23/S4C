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
using Excel = Microsoft.Office.Interop.Excel;
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
			try
			{
				var teach = StatisticFunction.TeacherWorkIsHard();
				var teachBd = BDConnection.connection.Teacher.ToList();
				var les = StatisticFunction.VisitStat();
				var students = BDConnection.connection.Student.ToList();
				var popular = StatisticFunction.MostPopularLesson();
				var productive = StatisticFunction.GetProductiveStuds();

				int rowIndex = 2;
				var application = new Excel.Application();
				application.SheetsInNewWorkbook = 4;
				Excel.Workbook workbook = application.Workbooks.Add(Type.Missing);
				Excel.Worksheet worksheet = application.Worksheets.Item[1];


				foreach (var i in teach)
				{
					Teacher teacher = teachBd.Where(x => x.ID == i.IdTeach).FirstOrDefault();
					worksheet.Name = $"Учитель";
					worksheet.Columns.AutoFit();
					worksheet.Rows.AutoFit();
					worksheet.Cells[1][1] = "Фамилия";
					worksheet.Cells[2][1] = "Имя";
					worksheet.Cells[3][1] = "Отчечтво";
					worksheet.Cells[4][1] = "Количество уроков";

					worksheet.Cells[1][rowIndex] = teacher.LastName;
					worksheet.Cells[2][rowIndex] = teacher.Name;
					worksheet.Cells[3][rowIndex] = teacher.Patronic;
					worksheet.Cells[4][rowIndex] = i.CountWork;

					rowIndex++;
				}
				rowIndex = 2;
				Excel.Worksheet worksheet1 = application.Worksheets.Item[2];
				foreach (var l in les)
				{
					Student stud = l.Student;
					worksheet1.Name = $"Посещаемость";
					worksheet1.Columns.AutoFit();
					worksheet1.Rows.AutoFit();
					worksheet1.Cells[1][1] = "Фамилия";
					worksheet1.Cells[2][1] = "Имя";
					worksheet1.Cells[3][1] = "Отчечтво";
					worksheet1.Cells[4][1] = "Название предмета";
					worksheet1.Cells[5][1] = "Количество посещенных уроков";

					foreach (var lesson in l.Lessons.Keys)
					{
						worksheet1.Cells[1][rowIndex] = stud.LastName;
						worksheet1.Cells[2][rowIndex] = stud.Name;
						worksheet1.Cells[3][rowIndex] = stud.Patronic;
						worksheet1.Cells[4][rowIndex] = lesson.Name;
						worksheet1.Cells[5][rowIndex] = l.Lessons[lesson];
						rowIndex++;

					}


				}
				rowIndex = 2;
				Excel.Worksheet worksheet2 = application.Worksheets.Item[3];
				popular = popular.OrderByDescending(x => x.count).ToList();
				foreach (var p in popular)
				{
					worksheet2.Name = $"Популярность кружков";
					worksheet2.Columns.AutoFit();
					worksheet2.Rows.AutoFit();
					worksheet2.Cells[1][1] = "Название";
					worksheet2.Cells[2][1] = "Количество учеников";

					worksheet2.Cells[1][rowIndex] = p.lesson1.Name;
					worksheet2.Cells[2][rowIndex] = p.count + " из " + p.lesson1.CountChildren;
					rowIndex++;

				}
				rowIndex = 2;
				Excel.Worksheet worksheet3 = application.Worksheets.Item[4];
				foreach (var p in productive)
				{
					worksheet3.Name = $"Продуктивность учеников";
					worksheet3.Columns.AutoFit();
					worksheet3.Rows.AutoFit();
					worksheet3.Cells[1][1] = "ФИО";
					worksheet3.Cells[2][1] = "Количество посещаемых кружков";

					worksheet3.Cells[1][rowIndex] = p.student1.LastName + " " + p.student1.Name + " " + p.student1.Patronic;
					worksheet3.Cells[2][rowIndex] = p.countless;
					rowIndex++;

				}
				application.Visible = true;
			}
			catch (Exception exp)
			{

			}
		}

        private void btnAddLessonClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddCirclePage());
        }

        private void lvTeacherSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(lvTeacher.SelectedItem != null)
            {
                var lesson = lvTeacher.SelectedItem as Lesson;
                NavigationService.Navigate(new RedactionCirclePage(lesson));
            }
        }
    }
}

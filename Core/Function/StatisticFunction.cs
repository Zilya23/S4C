using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataBase;

namespace Core.Function
{
	public class StatisticFunction
	{
		public class TeacherWork
		{
			public int IdTeach { get; set; }
			public int CountWork { get; set; }
		}


		public class GroupStat
		{
			public Student Student { get; set; }
			public Dictionary<Lesson, string> Lessons { get; set; }
		}
		public class PopularLesson
		{
			public Lesson lesson1 { get; set; }
			public int count { get; set; }
		}
		public class ProductiveStud
		{
			public Student student1 { get; set; }
			public int countless { get; set; }
		}
		public static List<TeacherWork> TeacherWorkIsHard()
		{
			var teachers = BDConnection.connection.Teacher.ToList();
			var lessons = BDConnection.connection.Lesson.ToList();
			List<TeacherWork> teacherWorks = new List<TeacherWork>();
			foreach (var i in teachers)
			{
				TeacherWork teacher = new TeacherWork();
				teacher.IdTeach = i.ID;
				teacher.CountWork = 0;
				foreach (var j in lessons)
				{
					if (i.ID == j.IDTeacher)
					{
						teacher.CountWork++;
					}
				}
				teacherWorks.Add(teacher);
			}
			return teacherWorks;
		}
		public static List<GroupStat> VisitStat()
		{
			var lessons = BDConnection.connection.Lesson.ToList();
			var timetable = BDConnection.connection.TimeLesson.ToList();
			var students = BDConnection.connection.Student.ToList();
			List<GroupStat> groupStats = new List<GroupStat>();

			foreach (var student in students)
			{
				var groupStat = new GroupStat() { Student = student, Lessons = new Dictionary<Lesson, string>() };
				foreach (var groupStatis in student.GroupStatistic)
				{
					var allLessons = 0;
					var visitedLessons = 0;
					foreach (var groupTime in groupStatis.GroupTime)
					{
						var lesson = groupTime.GroupStatistic.Lesson;

						if (groupTime.IsVisited)
							visitedLessons++;

						if (!groupStat.Lessons.ContainsKey(lesson))
						{
							allLessons = 0;
						}

						allLessons++;
						groupStat.Lessons[lesson] = $"{visitedLessons} из {allLessons}";

					}
				}
				groupStats.Add(groupStat);
			}
			return groupStats;
		}
		public static List<PopularLesson> MostPopularLesson()
		{
			List<PopularLesson> popularLessons = new List<PopularLesson>();
			var lessons = BDConnection.connection.Lesson.ToList();
			var groupStat = BDConnection.connection.GroupStatistic.ToList();
			foreach (var i in lessons)
			{
				PopularLesson popular = new PopularLesson();
				popular.lesson1 = i;
				popular.count = 0;
				foreach (var g in groupStat)
				{
					if (g.IDLesson == i.ID)
					{
						popular.count++;
					}
				}
				popularLessons.Add(popular);
			}
			return popularLessons;
		}
		public static List<ProductiveStud> GetProductiveStuds()
		{
			List<ProductiveStud> productives = new List<ProductiveStud>();
			var studs = BDConnection.connection.Student.ToList();
			var groupStat = BDConnection.connection.GroupStatistic.ToList();
			foreach (var s in studs)
			{
				ProductiveStud productive = new ProductiveStud();
				productive.student1 = s;
				productive.countless = 0;
				foreach (var g in groupStat)
				{
					if (g.IDStudent == s.ID)
					{
						productive.countless++;
					}
				}
				productives.Add(productive);
			}
			return productives;
		}
	}
}

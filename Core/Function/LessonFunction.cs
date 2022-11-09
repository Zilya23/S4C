using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataBase;

namespace Core.Function
{
    public class LessonFunction
    {
        public static List<Timetable> GetTimetables()
        {
            return BDConnection.connection.Timetable.Where(x => x.IsDelete != true).ToList();
        }

        public static List<Lesson> GetLessons()
        {
            return BDConnection.connection.Lesson.ToList();
        }

        public static void SaveLesson(Lesson lesson)
        {
            BDConnection.connection.Lesson.Add(lesson);
            BDConnection.connection.SaveChanges();
            //;fjghlfidjg;jng
        }
    }
}

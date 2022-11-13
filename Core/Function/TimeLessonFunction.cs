using Core.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Function
{
    public class TimeLessonFunction
    {
        public static List<TimeLesson> GetTimeLesson()
        {
            return BDConnection.connection.TimeLesson.ToList();
        }
        public static void SaveLesson(TimeLesson timeLesson)
        {
            BDConnection.connection.TimeLesson.Add(timeLesson);
            BDConnection.connection.SaveChanges();
            //;fjghlfidjg;jng
        }
    }
}


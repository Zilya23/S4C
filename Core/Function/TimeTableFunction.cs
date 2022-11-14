using Core.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Function
{
    public class TimeTableFunction
    {
        public static void SaveTimetable(Timetable timetable)
        {
            BDConnection.connection.Timetable.Add(timetable);
            BDConnection.connection.SaveChanges();
        }
    }
}

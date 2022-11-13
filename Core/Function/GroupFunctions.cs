using Core.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Function
{
    public class GroupFunctions
    {
        public static List<Timetable> GetTimes()
        {
            return BDConnection.connection.Timetable.ToList();
        }

        public static List<GroupStatistic> GetGroupStats()
        {
            return BDConnection.connection.GroupStatistic.ToList();
        }
    }
}

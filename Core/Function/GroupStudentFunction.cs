using Core.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Function
{
    public class GroupStudentFunction
    {
        public static List<GroupStatistic> GetGroupStatistic()
        {
            return BDConnection.connection.GroupStatistic.ToList();
        }
    }
}

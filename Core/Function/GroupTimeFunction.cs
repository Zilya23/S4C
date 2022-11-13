using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataBase;

namespace Core.Function
{
    public class GroupTimeFunction
    {
        public static List<GroupTime> GetGroupTime()
        {
            return BDConnection.connection.GroupTime.ToList();
        }
    }
}

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
        public static List<GroupTime> GetGroups()
        {
            return BDConnection.connection.GroupTime.ToList();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataBase;

namespace Core.Function
{
    public class EducationFunction
    {
        public static List<Education> GetEducations()
        {
            return BDConnection.connection.Education.ToList();
        }
    }
}

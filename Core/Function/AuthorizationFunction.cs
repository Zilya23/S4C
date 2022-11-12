using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataBase;

namespace Core.Function
{
    public class AuthorizationFunction
    {
        public static Teacher Authorization(string login, string password)
        {
            return BDConnection.connection.Teacher.FirstOrDefault(x => x.Password == password && x.Login == login);
        }
    }
}

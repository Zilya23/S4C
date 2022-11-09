using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataBase;

namespace Core.Function
{
    public class TeacherFunction
    {
        public static List<Teacher> GetTeachers()
        {
            return BDConnection.connection.Teacher.Where(x=> x.IsDelete != true).ToList();
        }

        public static bool SaveTeacher(Teacher teacher)
        {
            bool uniq = UniqLogin(teacher.Login);
            if(uniq)
            {
                BDConnection.connection.Teacher.Add(teacher);
                BDConnection.connection.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool UniqLogin(string login)
        {
            Teacher teacher = BDConnection.connection.Teacher.Where(x => x.Login == login).FirstOrDefault();
            if(teacher == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

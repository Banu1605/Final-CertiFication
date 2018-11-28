using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalCertification;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            UnitTestUser up = new UnitTestUser();
            up.GetUser();
            up.GetUsers();
            up.InsertUser();
            up.UpdateUser();
            up.DeleteUser();

            UnitTestTask ut = new UnitTestTask();
            ut.GetTask();
            ut.GetTasks();
            ut.InsertTask();
            ut.UpdateTask();
            ut.DeleteTask();
        }
    };

}
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FinalCertification.Controllers;
using FinalCertification.Models;
using System.Web.Http;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTestTask
    {
        [TestMethod]
        public void GetTask()
        {
            TasksController tc = new TasksController();
            Assert.IsNotNull(tc.GetTask("1"));
        }

        [TestMethod]
        public void GetTasks()
        {
            TasksController tc = new TasksController();
            Assert.IsNotNull(tc.GetTasks());
        }

        [TestMethod]
        public void InsertTask()
        {
            Task ts = new Task();
            ts.Task_ID = "1";
            ts.Task1 = "Unit Testing";
            ts.Start_Date = DateTime.Now;
            ts.End_Date = DateTime.Now;
            ts.Priority = "2";
            ts.Status = "InProgress";

            TasksController tc = new TasksController();
            Assert.IsNotNull(tc.PostTask(ts));
        }

        [TestMethod]
        public void UpdateTask()
        {
            Task ts = new Task();
            ts.Task_ID = "1";
            ts.Task1 = "Unit Testing1";
            ts.Start_Date = DateTime.Now;
            ts.End_Date = DateTime.Now;
            ts.Priority = "2";
            ts.Status = "InProgress";
            TasksController tc = new TasksController();
            Assert.IsNotNull(tc.PutTask("1",ts));
        }

        [TestMethod]
        public void DeleteTask()
        {
            TasksController tc = new TasksController();
            Assert.IsNotNull(tc.DeleteTask("1"));
        }
    }
}

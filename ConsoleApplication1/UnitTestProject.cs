using System;
using FinalCertification.Controllers;
using FinalCertification.Models;
using System.Web.Http;
using NUnit.Framework;

namespace ConsoleApplication1
{
    [TestFixture]
    public class UnitTestProject
    {
        [TestCase]
        public void GetProject()
        {
            ProjectsController tc = new ProjectsController();
            Assert.IsNotNull(tc.GetProject("1"));
        }

        [TestCase]
        public void GetProjects()
        {
            ProjectsController tc = new ProjectsController();
            Assert.IsNotNull(tc.GetProjects());
        }

        [TestCase]
        public void InsertProject()
        {
            Project ts = new Project();
            ts.Project_ID = "1";
            ts.Project1 = "Unit Testing";
            ts.StartDate = DateTime.Now;
            ts.EndDate = DateTime.Now;
            ts.Priority = "2";


            ProjectsController tc = new ProjectsController();
            Assert.IsNotNull(tc.PostProject(ts));
        }

        [TestCase]
        public void UpdateProject()
        {
            Project ts = new Project();
            ts.Project_ID = "1";
            ts.Project1 = "Unit Testing11";
            ts.StartDate = DateTime.Now;
            ts.EndDate = DateTime.Now;
            ts.Priority = "2";
            ProjectsController tc = new ProjectsController();
            Assert.IsNotNull(tc.PutProject("2", ts));
        }

        [TestCase]
        public void DeleteProject()
        {
            ProjectsController tc = new ProjectsController();
            Assert.IsNotNull(tc.DeleteProject("2"));
        }
    }
}

using System;
using FinalCertification.Controllers;
using FinalCertification.Models;
using System.Web.Http;
using NUnit.Framework;

namespace FinalCertification.Tests
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
            ts.Project_ID = "2";
            ts.Project1 = "Unit Testing1";
            ts.StartDate = DateTime.Now;
            ts.EndDate = DateTime.Now;
            ts.Priority = "2";
            
           
            ProjectsController tc = new ProjectsController();
           
            tc.PostProject(ts);
            Assert.IsNotNull(tc.GetProject("2"));
        }

        [TestCase]
        public void UpdateProject()
        {
            Project ts = new Project();
            ts.Project_ID = "2";
            ts.Project1 = "Unit Testing12";
            ts.StartDate = DateTime.Now;
            ts.EndDate = DateTime.Now;
            ts.Priority = "2";
            ProjectsController tc = new ProjectsController();
            tc.PutProject("2", ts);
            Assert.AreEqual(ts,tc.GetProject("2"));
        }

        [TestCase]
        public void DeleteProject()
        {
            ProjectsController tc = new ProjectsController();
            tc.DeleteProject("2");
            Assert.IsNull(tc.GetProject("2"));
        }
    }
}

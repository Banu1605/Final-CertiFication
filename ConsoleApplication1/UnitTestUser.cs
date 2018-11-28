using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FinalCertification.Controllers;
using FinalCertification.Models;
using System.Web.Http;
using System.Net;
using System.Web.Http.Results;

namespace ConsoleApplication1
{
    [TestClass]
    public class UnitTestUser
    {

        [TestMethod]
        public void GetUser()
        {
           string str = "1";
            UsersController uc = new UsersController();
            Assert.IsNotNull(uc.GetUser(str));
        }
        [TestMethod]
        public void GetUsers()
        {
            UsersController uc = new UsersController();
            Assert.IsNotNull(uc.GetUsers());
        }
        [TestMethod]
        public void InsertUser()
        {
            User us = new User();
            us.User_ID = "2";
            us.First_Name = "Arul";
            us.Last_Name = "Raj";
            us.Employee_ID = 668010;
            
            UsersController uc = new UsersController();
            Assert.IsNotNull(uc.PostUser(us));
        }
        [TestMethod]
        public void UpdateUser()
        {
            User us = new User();
            us.User_ID = "2";
            us.First_Name = "Arul";
            us.Last_Name = "Raji";
            us.Employee_ID = 668010;
            
            UsersController uc = new UsersController();
            IHttpActionResult actionResult = uc.PutUser("2", us);  
            var contentResult = actionResult as NegotiatedContentResult < User > ;
            Assert.AreEqual(HttpStatusCode.Accepted, contentResult.StatusCode);
            Assert.IsNotNull(contentResult);
        }
        [TestMethod]
        public void DeleteUser()
        {
            UsersController uc = new UsersController();
            Assert.IsNotNull(uc.DeleteUser("1"));
        }

       

    }
}

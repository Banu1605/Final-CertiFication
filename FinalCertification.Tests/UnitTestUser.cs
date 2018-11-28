using System;
using FinalCertification.Controllers;
using FinalCertification.Models;
using System.Web.Http;
using System.Net;
using System.Web.Http.Results;
using NUnit.Framework;

namespace FinalCertification.Tests
{
    [TestFixture]
    public class UnitTestUser
    {

        [TestCase]
        public void GetUser()
        {
           string str = "1";
            UsersController uc = new UsersController();
            Assert.IsNotNull(uc.GetUser(str));
        }
        [TestCase]
        public void GetUsers()
        {
            UsersController uc = new UsersController();
            Assert.IsNotNull(uc.GetUsers());
        }
        [TestCase]
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
        [TestCase]
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
        [TestCase]
        public void DeleteUser()
        {
            UsersController uc = new UsersController();
            Assert.IsNotNull(uc.DeleteUser("1"));
        }

       

    }
}

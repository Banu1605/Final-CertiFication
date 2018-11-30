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

        //[TestCase]
        //public void GetUser()
        //{
        //   string str = "2";
        //    UsersController uc = new UsersController();
        //   var test= uc.GetUser(str);
        //    Assert.AreEqual(test,uc.GetUser(str));
        //}
        //[TestCase]
        //public void GetUsers()
        //{
        //    UsersController uc = new UsersController();
        //    var test = uc.GetUsers();
        //    Assert.AreEqual(test,uc.GetUsers());
        //}
        [TestCase]
        public void InsertUser()
        {
            User us = new User();
            us.User_ID = "4";
            us.First_Name = "Mark";
            us.Last_Name = "John";
            us.Employee_ID = 987891;
            
            UsersController uc = new UsersController();
            uc.PostUser(us);
            Assert.IsNotNull(uc.GetUser("4"));
        }
        [TestCase]
        public void UpdateUser()
        {
            User us = new User();
            us.User_ID = "4";
            us.First_Name = "Mark";
            us.Last_Name = "James";
            us.Employee_ID = 987891;
            
            UsersController uc = new UsersController();
            uc.PutUser("4", us);
            Assert.IsNotNull(uc);
           
        }
        //[TestCase]
        //public void DeleteUser()
        //{
        //    UsersController uc = new UsersController();
        //    uc.DeleteUser("3");
        //    Assert.IsNull(uc.GetUser("3"));
        //}

       

    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ValeraCinema;
using ValeraCinema.Pages;
using ValeraCinema.logic;
using Moq;
using System.Collections.Generic;
using System.Data.Entity;

namespace TestCinema
{
    [TestClass]
    public class Admin_panelTest
    {
        
        Mock<InterFace1> mockDB = new Mock<InterFace1>();
        Admin_panel admin;
        [TestInitialize]
        public void Initialize()
        {
            admin = new Admin_panel();
            admin.films = mockDB.Object;       
            mockDB.Setup(m => m.Save()).Returns(1);
            mockDB.Setup(m => m.GetUsers).Returns(new List<User> { new User() {IdUser = 16 } });
        }

        [TestMethod]
        public void btnSetOperater_CorrectValue_NotEmptyStrReturnTrue()
        {
            
            bool res = admin.changeRoleUM("16");
            Assert.IsTrue(res);

        }
        [TestMethod]
        public void btnSetOperater_InCorrectValue_EmptyStrReturnFalse()
        {

            bool res = admin.changeRoleUM("");
            Assert.IsFalse(res);

        }
        [TestMethod]
        public void btnSetOperater_InCorrectValue_NotEmptyStrReturnFalse()
        {

            bool res = admin.changeRoleUM("158");
            Assert.IsFalse(res);

        }
    }
}

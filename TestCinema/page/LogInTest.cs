using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ValeraCinema;
using ValeraCinema.logic;
using ValeraCinema.Pages;

namespace TestCinema
{

    [TestClass]
    public class LogInTest
    {
        Mock<InterFace1> mockDB = new Mock<InterFace1>();

        public List<User> userList = new List<User>();
        public LogIn login = new LogIn();

        [TestMethod]
        public void CheckLogIn_InCorrectValue_LessFieldReturnFalse()
        {
            List<TextBox> txtList = new List<TextBox>();
            TextBox textBox1 = new TextBox();
            List<User> userList = new List<User>();
            int expected = 0;
            txtList.Add(textBox1);
            login.CheckLogin(txtList, userList);
            Assert.AreEqual(expected, User.getInstance().IdUser);
        }

        [TestMethod]
        public void CheckLogIn_InCorrectValue_EmptyFieldReturnFalse()
        {
            List<TextBox> txtList = new List<TextBox>();
            TextBox textBox1 = new TextBox();
            TextBox textBox2 = new TextBox();
            textBox1.Text = "";
            List<User> userList = new List<User>();
            int expected = 0;
            txtList.Add(textBox1);
            txtList.Add(textBox2);
            login.CheckLogin(txtList, userList);
            Assert.AreEqual(expected, User.getInstance().IdUser);
        }

        [TestMethod]
        public void CheckLogIn_InCorrectValue_EmptyUsersReturnFalse()
        {
            List<TextBox> txtList = new List<TextBox>();
            TextBox textBox1 = new TextBox();
            TextBox textBox2 = new TextBox();
            textBox1.Text = "user";
            textBox2.Text = "user";
            List<User> userList = new List<User>();
            int expected = 0;
            txtList.Add(textBox1);
            txtList.Add(textBox2);
            login.CheckLogin(txtList, userList);
            Assert.AreEqual(expected, User.getInstance().IdUser);
        }

        public void init()
        {
            userList = new List<User>();
            User u = new User();
            u.IdUser = 1;
            u.Nickname = "user";
            u.Password = "user";
            userList.Add(u);
        }

        [TestMethod]
        public void CheckLogIn_InCorrectValue_NotFoundUserReturnFalse()
        {
            List<TextBox> txtList = new List<TextBox>();
            TextBox textBox1 = new TextBox();
            TextBox textBox2 = new TextBox();
            textBox1.Text = "login";
            textBox2.Text = "login";
            init();
            int expected = 0;
            txtList.Add(textBox1);
            txtList.Add(textBox2);
            login.CheckLogin(txtList, userList);
            Assert.AreEqual(expected, User.getInstance().IdUser);
        }

        [TestMethod]
        public void CheckLogIn_CorrectValue_FoundUserReturnTrue()
        {
            List<TextBox> txtList = new List<TextBox>();
            TextBox textBox1 = new TextBox();
            TextBox textBox2 = new TextBox();
            textBox1.Text = "user";
            textBox2.Text = "user";
            init();
            int expected = 1;
            txtList.Add(textBox1);
            txtList.Add(textBox2);
            login.CheckLogin(txtList, userList);
            Assert.AreEqual(expected, User.getInstance().IdUser);
        }

        //[TestMethod]
        //public void Login_InCurrectValue_EmptyLoginAndPassword_returnDialog()
        //{
        //    string login = ""; string pw = "";
        //    LogIn li = new LogIn();
        //    li.CheckLogin(login, pw);

        //    Assert.AreEqual(0, User.getInstance().IdUser);
        //}

        //[TestMethod]
        //public void Login_InCurrectValue_EmptyPasswordStr_returnDialog()
        //{
        //    string login = "admin"; string pw = "";
        //    LogIn li = new LogIn();
        //    li.CheckLogin(login, pw);

        //    Assert.AreEqual(0, User.getInstance().IdUser);
        //}

        //[TestMethod]
        //public void Login_InCurrectValue_EmptyLoginStr_returnDialog()
        //{
        //    string login = ""; string pw = "admin";
        //    LogIn li = new LogIn();
        //    li.CheckLogin(login, pw);

        //    Assert.AreEqual(0, User.getInstance().IdUser);
        //}

        //[TestMethod]
        //public void Login_InCurrectValuePassword__returnDialog()
        //{
        //    string login = "admin"; string pw = "user";
        //    int expected = 0;
        //    LogIn li = new LogIn();
        //    li.CheckLogin(login, pw);

        //    Assert.AreEqual(expected, User.getInstance().IdUser);
        //}

        //[TestMethod]
        //public void Login_CurrectValue__returnDialog()
        //{
        //    string login = "admin"; string pw = "admin";
        //    LogIn li = new LogIn();
        //    li.CheckLogin(login, pw);

        //    Assert.AreEqual(0, User.getInstance().IdUser);
        //}



    }
}

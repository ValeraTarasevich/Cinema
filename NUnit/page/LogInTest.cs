﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Moq;
using NUnit.Framework;
using ValeraCinema;
using ValeraCinema.logic;
using ValeraCinema.Pages;

namespace NUnit.page
{
    [TestFixture]
    public class LogInTest
    {
        Mock<InterFace1> mockDB = new Mock<InterFace1>();
        public List<User> userList;
        public LogIn login;

       [SetUp]
        public void Init()
        {
            userList = new List<User>();
            login = new LogIn();

    }

    [Test]
        public void NUnitCheckLogIn_InCorrectValue_LessFieldReturnFalse()
        {
            List<TextBox> txtList = new List<TextBox>();
            TextBox textBox1 = new TextBox();
            List<User> userList = new List<User>();
            int expected = 0;
            txtList.Add(textBox1);
            login.CheckLogin(txtList, userList);
            Assert.AreEqual(expected, User.getInstance().IdUser);
        }

        [Test]
        public void NUnitCheckLogIn_InCorrectValue_EmptyFieldReturnFalse()
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

        [Test]
        public void NUnitCheckLogIn_InCorrectValue_EmptyUsersReturnFalse()
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

        [Test]
        public void NUnitCheckLogIn_InCorrectValue_NotFoundUserReturnFalse()
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

        [Test]
        public void NUnitCheckLogIn_CorrectValue_FoundUserReturnTrue()
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

    }
}

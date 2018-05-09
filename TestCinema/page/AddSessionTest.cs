using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ValeraCinema;
using ValeraCinema.Pages;

namespace TestCinema.page
{
    [TestClass]
    public class AddSessionTest
    {
        AddSession add = new AddSession();
        List<Film> filmList = new List<Film>();
        List<TextBox> txtList = new List<TextBox>();
        List<DateTimePicker> dateList = new List<DateTimePicker>();

        [TestMethod]
        public void filmValid_InCorrectValue_EmptyFieldReturnNull()
        { 
            List<TextBox> txtList = new List<TextBox>();
            List<DateTimePicker> dateList = new List<DateTimePicker>();
            TextBox textBox1 = new TextBox();
            TextBox textBox2 = new TextBox();
            
            txtList.Add(textBox1);
            txtList.Add(textBox2);
            Assert.IsNull(add.filmValid(txtList, dateList, filmList));
        }
        [TestInitialize]
        public void initialize()
        {
            txtList = new List<TextBox>();
            dateList = new List<DateTimePicker>();
            TextBox textBox1 = new TextBox(); textBox1.Text = "Дедпул";
            TextBox textBox2 = new TextBox(); textBox2.Text = "Паренек помогает всем";
            TextBox textBox3 = new TextBox(); textBox3.Text = "США";
            TextBox textBox4 = new TextBox(); textBox4.Text = "Фантастика";
            TextBox textBox5 = new TextBox(); textBox5.Text = "2016";
            TextBox textBox6 = new TextBox(); textBox6.Text = "8";
            TextBox textBox7 = new TextBox(); textBox7.Text = "10";
            DateTimePicker dateTime1 = new DateTimePicker(); dateTime1.Value = DateTime.Now;
            DateTime date = DateTime.Now;
            date.AddMonths(3);
            DateTimePicker dateTime2 = new DateTimePicker(); dateTime2.Value = date;

            txtList.Add(textBox1);
            txtList.Add(textBox2);
            txtList.Add(textBox3);
            txtList.Add(textBox4);
            txtList.Add(textBox5);
            txtList.Add(textBox6);
            txtList.Add(textBox7);
            dateList.Add(dateTime1);
            dateList.Add(dateTime2);

           filmList = new List<Film>();
           Film f = new Film();
           f.Name = "Kill";
           f.Style = "dram";
           f.Year = 1999;
           f.Country = "Belarus";
           filmList.Add(f);
           
        }

        [TestMethod]
        public void filmValid_InCorrectValue_EmptyNameReturnNull()
        {
            initialize();
            txtList[0].Text = "";
            Assert.IsNull(add.filmValid(txtList, dateList, filmList));
        }

        [TestMethod]
        public void filmValid_InCorrectValue_EmptyDataReturnNotNull()
        {
            initialize();
            filmList.Clear();
            Assert.IsNotNull(add.filmValid(txtList, dateList, filmList));
        }

        [TestMethod]
        public void filmValid_CorrectValue_NoRepeatReturnNotNull()
        {
            initialize();
            Assert.IsNotNull(add.filmValid(txtList, dateList, filmList));
        }

        [TestMethod]
        public void filmValid_InCorrectValue_RepeatReturnNull()
        {
            initialize();
            Film f = new Film();
            f.Name = "Дедпул";
            f.Style = "Фантастика";
            f.Year = 2016;
            f.Country = "США";
            filmList.Add(f);
            Assert.IsNull(add.filmValid(txtList, dateList, filmList));
        }


    }
}

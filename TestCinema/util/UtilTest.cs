using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ValeraCinema.util;

namespace TestCinema.util
{
    [TestClass]
    public class UtilTest
    {
        [TestMethod]
        public void CheckTextBoxes_InCorrectValue_EmptyTextboxReturnFalse()
        {
            List<TextBox> txtList = new List<TextBox>();
            TextBox textBox1 = new TextBox();
            TextBox textBox2 = new TextBox();
            txtList.Add(textBox1);
            txtList.Add(textBox2);
            Assert.IsFalse(Util.CheckTextBoxes(txtList));

        }

        [TestMethod]
        public void CheckTextBoxes_InCorrectValue_ReturnNotNull()
        {
            List<TextBox> txtList = new List<TextBox>();
            txtList.Clear();
            Assert.IsNotNull(Util.CheckTextBoxes(txtList));

        }

        [TestMethod]
        public void CheckTextBoxes_CorrectValue_SuccessReturnTrue()
        {
            List<TextBox> txtList = new List<TextBox>();
            TextBox textBox1 = new TextBox();
            textBox1.Text = "hello";
            TextBox textBox2 = new TextBox();
            textBox2.Text = "Bro";
            txtList.Add(textBox1);
            txtList.Add(textBox2);
            Assert.IsTrue(Util.CheckTextBoxes(txtList));

        }

        //[TestMethod]
        //public void CheckDates_EmptyTextbox()
        //{
        //    List<DateTimePicker> dateList = new List<DateTimePicker>();
        //    DateTimePicker dateTime1 = new DateTimePicker();
        //    DateTimePicker dateTime2 = new DateTimePicker();
        //    dateList.Add(dateTime1);
        //    dateList.Add(dateTime2);
        //    Assert.IsFalse(add.CheckDates(dateList));
        //}

        //[TestMethod]
        //public void CheckDates_CorrectValue_SuccessReturnTrue()
        //{
        //    List<DateTimePicker> dateList = new List<DateTimePicker>();
        //    DateTimePicker dateTime1 = new DateTimePicker();
        //    dateTime1.Value = DateTime.Now;
        //    DateTimePicker dateTime2 = new DateTimePicker();
        //    dateTime2.Value = DateTime.Now;
        //    Assert.IsTrue(Util.CheckDates(dateList));
        //}

    }
}

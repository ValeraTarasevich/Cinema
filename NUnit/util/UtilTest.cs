using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ValeraCinema.util;

namespace NUnit.util
{
    [TestFixture]
    public class UtilTest
    {
        [Test]
        public void NUnitCheckTextBoxes_InCorrectValue_EmptyTextboxReturnFalse()
        {
            List<TextBox> txtList = new List<TextBox>();
            TextBox textBox1 = new TextBox();
            TextBox textBox2 = new TextBox();
            txtList.Add(textBox1);
            txtList.Add(textBox2);
            Assert.IsFalse(Util.CheckTextBoxes(txtList));

        }

        [Test]
        public void CheckTextBoxes_InCorrectValue_ReturnNotNull()
        {
            List<TextBox> txtList = new List<TextBox>();
            txtList.Clear();
            Assert.IsNotNull(Util.CheckTextBoxes(txtList));

        }

        [Test]
        public void NUnitCheckTextBoxes_CorrectValue_SuccessReturnTrue()
        {
            List<TextBox> txtList = new List<TextBox>();
            TextBox textBox1 = new TextBox();
            textBox1.Text = "hello";
            TextBox textBox2 = new TextBox();
            textBox2.Text = "good";
            txtList.Add(textBox1);
            txtList.Add(textBox2);
            Assert.IsTrue(Util.CheckTextBoxes(txtList));

        }

        //[Test]
        //public void NUnitCheckDates_CorrectValue_SuccessReturnTrue()
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

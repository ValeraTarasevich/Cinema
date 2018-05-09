using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ValeraCinema;
using ValeraCinema.logic;

namespace TestCinema.logic
{
    [TestClass]
    public class SearchTest
    {
        List<Film> list;

        private void init()
        {
            list = new List<Film>();
            Film f = new Film();
            f.Name = "qwe";
            f.Style = "dram";
            f.Year = 1234;
            f.Country = "Belarus";
            list.Add(f);
        }

        [TestMethod]
        public void find_InCorrectValue_EmptylistReturnNull()
        {
            ISearch search = new Search();
            Assert.IsNull(search.find(null, "name"));
        }

        [TestMethod]
        public void find_InCorrectValue_EmptyMsgReturnNull()
        {
            ISearch search = new Search();
            init();
            Assert.IsNull(search.find(list, null));
        }

        [TestMethod]
        public void find_CorrectValue_FoundСoncurrenceReturnTrue()
        {
            ISearch search = new Search();
            init();
            int expected = 1;
            String msg = list[0].Name;
            Assert.AreEqual(expected, search.find(list, msg).Count);
        }

    }
}

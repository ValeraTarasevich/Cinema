using System;
using System.Collections.Generic;
using NUnit.Framework;
using ValeraCinema;
using ValeraCinema.logic;

namespace NUnit.logic
{
    [TestFixture]
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

        [Test]
        public void NUnitfind_InCorrectValue_EmptylistReturnNull()
        {
            ISearch search = new Search();
            list.Clear();
            Assert.IsNull(search.find(list, "name"));
        }

        [Test]
        public void NUnitfind_InCorrectValue_EmptyMsgReturnNull()
        {
            ISearch search = new Search();
            init();
            Assert.IsNull(search.find(list, null));
        }

        [Test]
        public void NUnitfind_CorrectValue_FoundСoncurrenceReturnTrue()
        {
            ISearch search = new Search();
            init();
            int expected = 1;
            String msg = list[0].Name;
            Assert.AreEqual(expected, search.find(list, msg).Count);
        }

    }
}

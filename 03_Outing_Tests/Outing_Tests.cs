using System;
using System.Collections.Generic;
using _03_Outing_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _03_Outing_Tests
{
    [TestClass]
    public class Outing_Tests
    {
        [TestMethod]
        public void TestAdd()
        {
            Outing_Repository outingRepo = new Outing_Repository();
            Outing newOuting = new Outing(OutingType.Bowling, 2, new DateTime(12, 12, 12), 2.00d, 2000d);
            Outing newOuting2 = new Outing(OutingType.Bowling, 2, new DateTime(12, 12, 12), 2.00d, 2000d);

            outingRepo.AddToList(newOuting);
            outingRepo.AddToList(newOuting2);
            List<Outing> list = outingRepo.GetOutingList();

            int actual = list.Count;
            int expected = 2;

            Assert.AreEqual(expected, actual);
            Assert.IsTrue(list.Contains(newOuting));

            Console.WriteLine($"{expected} = {actual}");
        }
        [TestMethod]
        public void TestTotals()
        {
            Outing_Repository outingRepo = new Outing_Repository();
            Outing newOuting = new Outing(OutingType.Bowling, 2, new DateTime(12, 12, 12), 2.00d, 2000d);
            Outing newOuting2 = new Outing(OutingType.Bowling, 2, new DateTime(12, 12, 12), 2.00d, 2000d);
        }
    }
}

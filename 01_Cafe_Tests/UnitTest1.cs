using System;
using _01_Cafe_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _01_Cafe_Tests
{
    [TestClass]
    public class UnitTest1
    {
        public Cafe_Repository _cafeRepo = new Cafe_Repository();

        [TestMethod]
        public void TestMethod1()
        {
            Product prod = new Product(1, "Hamburger", "Juicy burger", "Bun and lettuce and patty", 20.00d);
            Product prod2 = new Product(2, "Hamburger2", "Juicy burger", "Bun and lettuce and patty", 20.00d);

            _cafeRepo.AddToList(prod);
            _cafeRepo.AddToList(prod2);

            _cafeRepo.CheckIfExists(1);
            Assert.IsTrue(_cafeRepo.CheckIfExists(1));
        }
    }
}

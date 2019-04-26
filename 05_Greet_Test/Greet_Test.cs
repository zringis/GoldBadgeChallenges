using System;
using System.Collections.Generic;
using System.Linq;
using _05_Greet_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _05_Greet_Test
{
    [TestClass]
    public class Greet_Test
    {
        private Greet_Repository _greetingRepo = new Greet_Repository();
        private List<Greet> _greet = new List<Greet>();
        [TestMethod]
        public void TestAdd()
        {
            Greet newGreeting0 = new Greet("Adim", "Zigunus", CustomerType.Potential, "Not sure why you havent joined us yet, what are you waiting for?");
            _greetingRepo.AddToList(newGreeting0);
            Greet newGreeting1 = new Greet("Tom", "Barker", CustomerType.Current, "Thank you for being a customer! Next Month We Will Send You A Coupon!");
            _greetingRepo.AddToList(newGreeting1);
            Greet newGreeting2 = new Greet("James", "Arkin", CustomerType.Past, "For being a past customer, we will offer you lower rates!");
            _greetingRepo.AddToList(newGreeting2);
            Greet newGreeting3 = new Greet("Zachary", "Arkin", CustomerType.Potential, "We have the LOWEST rates on helicopter insurance! Give us a ring!");
            _greetingRepo.AddToList(newGreeting3);
            Greet newGreeting4 = new Greet("Donnovan", "Domino", CustomerType.Current, "Thank you for being a customer! Next Month We Will Send You A Coupon!");
            _greetingRepo.AddToList(newGreeting4);
            Greet newGreeting5 = new Greet("Zdim", "Aigunus", CustomerType.Potential, "Cmonnnnnn you're over paying for insurance. Don't wait! Join Us!");
            _greetingRepo.AddToList(newGreeting5);

            _greetingRepo.ViewList();

            Console.WriteLine($" {_greetingRepo.ViewList()} ");

            var expected = 6;
            var actual = _greetingRepo.GetListCount();

            Console.WriteLine($"{expected} {actual}");

            Assert.AreEqual(actual, expected);
        }
        [TestMethod]
        public void TestRead()
        {
            Greet newGreeting0 = new Greet("Adim", "Zigunus", CustomerType.Potential, "Not sure why you havent joined us yet, what are you waiting for?");
            _greetingRepo.AddToList(newGreeting0);

            _greetingRepo.ViewList();

            Console.WriteLine($" {_greetingRepo.ViewList()} "); 
        }
        [TestMethod]
        public void TestUpdate()
        {
            Greet newGreeting0 = new Greet("Adim", "Zigunus", CustomerType.Potential, "Not sure why you havent joined us yet, what are you waiting for?");
            _greetingRepo.AddToList(newGreeting0);
            Console.WriteLine("Orig:");
            Console.WriteLine($"{newGreeting0.FirstName} {newGreeting0.LastName} {newGreeting0.Type} {newGreeting0.Email}");

            _greetingRepo.UpdateFirstName("adim", "zigunus", "update1");


            _greetingRepo.UpdateLastName("update1", "zigunus", "update2");

            _greetingRepo.UpdateCustomerType("update1", "update2", CustomerType.Current);

            _greetingRepo.UpdateEmail("update1", "update2", "sup dawg this be a banana");

            Console.WriteLine("Changed to:");
            Console.WriteLine($"{newGreeting0.FirstName} {newGreeting0.LastName} {newGreeting0.Type} {newGreeting0.Email}");



        }

        [TestMethod]
        public void TestDelete()
        {
            Greet newGreeting0 = new Greet("Adim", "Zigunus", CustomerType.Potential, "Not sure why you havent joined us yet, what are you waiting for?");
            _greetingRepo.AddToList(newGreeting0);
            Greet newGreeting1 = new Greet("Tom", "Barker", CustomerType.Current, "Thank you for being a customer! Next Month We Will Send You A Coupon!");
            _greetingRepo.AddToList(newGreeting1);

            _greetingRepo.DeleteCustomer(newGreeting0);
        }
    }
}

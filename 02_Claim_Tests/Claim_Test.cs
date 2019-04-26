using System;
using _02_Claim_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _02_Claim_Tests
{
    [TestClass]
    public class Claim_Test
    {
        private Claim_Repository _claimRepo = new Claim_Repository();

        [TestMethod]
        public void TestAll()
        {
            ClaimContent claim1 = new ClaimContent(1, "House", "Tree Fell on Roof", 500.00d, new DateTime(2019, 01, 22), new DateTime(2019, 01, 24), true);
            _claimRepo.AddToQueue(claim1);

            ClaimContent claim2 = new ClaimContent(2, "Car", "Car Accident on I-69", 250.00d, new DateTime(2019, 02, 23), new DateTime(2019, 03, 01), true);
            _claimRepo.AddToQueue(claim2);

            ClaimContent claim3 = new ClaimContent(3, "Theft", "Stolen Pancakes", 4.00d, new DateTime(2019, 03, 20), new DateTime(2019, 03, 22), false);
            _claimRepo.AddToQueue(claim3);

            //bool properlyAdded = _claimRepo.HasContent();
            //Assert.IsTrue(properlyAdded);
            //Console.WriteLine($"{properlyAdded}");


            Console.WriteLine($"{_claimRepo.ViewNextClaim()} {_claimRepo.GetClaimQueue()}");
            _claimRepo.DealWithClaim();
            Console.WriteLine($"{_claimRepo.ViewNextClaim()}");

            _claimRepo.GetClaimQueue();

            bool hasContent = _claimRepo.HasContent();
            Assert.IsTrue(hasContent);

            int newClaimNum = _claimRepo.GetClaimNumber();
            Assert.AreEqual(4, newClaimNum);

        }
    }
}

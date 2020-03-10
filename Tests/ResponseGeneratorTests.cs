using System;
using System.Collections.Generic;
using System.Text;
using Library;
using NUnit.Framework;

namespace Tests
{
    class ResponseGeneratorTests
    {
        [Test]
        public void CheckNumber_GivenCompositeNumber_ReturnsRightMessage()
        {
            List<int> temp = new List<int>();
            int updatedCurrentHighest;
            Assert.AreEqual("No, that's not a prime number", ResponseGenerator.CheckNumber("9", temp, 0, out updatedCurrentHighest));
        }

        [Test]
        public void CheckNumber_GivenNegativeNumber_ReturnsRightMessage()
        {
            List<int> temp = new List<int>();
            int updatedCurrentHighest;
            Assert.AreEqual("No, that's not a prime number", ResponseGenerator.CheckNumber("-7", temp, 0, out updatedCurrentHighest));
        }

        [Test]
        public void CheckNumber_GivenPrimeNumber_ReturnsRightMessage()
        {
            List<int> temp = new List<int>();
            int updatedCurrentHighest;
            Assert.AreEqual("Yep, that's a prime number. It's added to the list", ResponseGenerator.CheckNumber("5", temp, 0, out updatedCurrentHighest));
        }

        [Test]
        public void CheckNumber_GivenPrimeNumber_AddsPrimeNumberToList()
        {
            List<int> temp = new List<int>();
            int updatedCurrentHighest;
            ResponseGenerator.CheckNumber("5", temp, 0, out updatedCurrentHighest);

            Assert.AreEqual(1, temp.Count);
            Assert.AreEqual(5, temp[0]);
        }

        [Test]
        public void CheckNumber_GivenPrimeNumberLargerThanCurrentHighestPrime_UpdatesCurrentHighestPrime()
        {
            List<int> temp = new List<int>();
            int currentHighestPrime = 5;
            int updatedCurrentHighest;
            ResponseGenerator.CheckNumber("7", temp, currentHighestPrime, out updatedCurrentHighest);
            currentHighestPrime = updatedCurrentHighest;

            Assert.AreEqual(7, currentHighestPrime);
        }

        [Test]
        public void PrintNextPrimeNumber_CurrentHighestBeing5_ReturnsRightMessage()
        {
            List<int> temp = new List<int>{ 5 };
            int updatedCurrentHighest;
            Assert.AreEqual("The next prime number would be 7. We have added it to the list", ResponseGenerator.PrintNextPrimeNumber(5,temp, out updatedCurrentHighest));
        }

        [Test]
        public void PrintNextPrimeNumber_WhenListIsEmpty_ReturnsRightMessage()
        {
            List<int> temp = new List<int>();
            int updatedCurrentHighest;
            Assert.AreEqual("The list is empty, you must have at least one prime number in the list to use this function", ResponseGenerator.PrintNextPrimeNumber(0, temp, out updatedCurrentHighest));
        }


        [Test]
        public void PrintPrimeNumberList_WithListOf3Primes_ReturnsRightMessage()
        {
            List<int> temp = new List<int> { 5, 7, 11 };
            Assert.AreEqual("Current prime numbers: 5,7,11,", ResponseGenerator.PrintPrimeNumberList(temp));
        }

        [Test]
        public void PrintPrimeNumberList_WhenListIsEmpty_ReturnsRightMessage()
        {
            List<int> temp = new List<int>();
            Assert.AreEqual("The list is empty", ResponseGenerator.PrintPrimeNumberList(temp));
        }
    }
}

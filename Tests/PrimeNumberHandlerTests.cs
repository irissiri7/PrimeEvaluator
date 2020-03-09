using NUnit.Framework;
using System.Collections.Generic;
using Library;
using System;

namespace Tests
{
    class PrimeNumberHandlerTests
    {

        [Test]
        public void CheckIfPrime_GivenZero_ReturnsFalse()
        {
            
            Assert.IsFalse(PrimeNumberHandler.CheckIfPrime(0));
            
        }

        [Test]
        public void CheckIfPrime_GivenOne_ReturnsFalse()
        {

            Assert.IsFalse(PrimeNumberHandler.CheckIfPrime(1));

        }

        [Test]
        public void CheckIfPrime_GivenListOfSmallPrimeNumbers_ReturnsTrueForEveryNumber()
        {
            List<int> smallPrimeNumbers = new List<int> { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37};
            
            foreach(int num in smallPrimeNumbers)
            {
                Assert.IsTrue(PrimeNumberHandler.CheckIfPrime(num));
            }
            
        }

        [Test]
        public void CheckIfPrime_GivenListOfBigPrimeNumbers_ReturnsTrueForEveryNumber()
        {
            List<int> bigPrimeNumbers = new List<int> { 100057, 102233, 202481, 200899, 302563, 1000099 };

            foreach (int num in bigPrimeNumbers)
            {
                Assert.IsTrue(PrimeNumberHandler.CheckIfPrime(num));
            }

        }

        [Test]
        public void CheckIfPrime_GivenListOfCompositeNumbers_ReturnsFalseForEveryNumber()
        {
            List<int> compositeNumbers = new List<int> { 4, 6, 8, 10, 20, 25, 30 };
            foreach (int num in compositeNumbers)
            {
                Assert.IsFalse(PrimeNumberHandler.CheckIfPrime(num));
            }
        }

        [Test]
        public void CheckIfPrime_GivenListOfNegativeCompositeNumbers_ReturnsFalseForEveryNumber()
        {
            List<int> negativeCompositeNumbers = new List<int> { -4, -6, -8, -10, -20, -25, -30 };
            foreach (int num in negativeCompositeNumbers)
            {
                Assert.IsFalse(PrimeNumberHandler.CheckIfPrime(num));
            }
        }


        [Test]
        public void CheckIfPrime_GiveNegativeSmallPrimes_ReturnsFalseForEveryNumber()
        {

            List<int> smallNegativePrimeNumbers = new List<int> { -2, -3, -5, -7, -11, -13, -17, -19, -23, -29, -31, -37 };

            foreach (int num in smallNegativePrimeNumbers)
            {
                Assert.IsFalse(PrimeNumberHandler.CheckIfPrime(num));
            }

        }

        [Test]
        public void CheckIfPrime_GiveNegativeBigPrimes_ReturnsFalseForEveryNumber()
        {

            List<int> bigNegativePrimeNumbers = new List<int> { -100057, -102233, -202481, -200899, -302563, -1000099 };

            foreach (int num in bigNegativePrimeNumbers)
            {
                Assert.IsFalse(PrimeNumberHandler.CheckIfPrime(num));
            }

        }

        [Test]
        public void FindNextPrime_Generating10000Numbers_AlwaysReturnsAPrime()
        {

            Random rdn = new Random();
            for(int i = 0; i < 10000; i++)
            {
                Assert.IsTrue(PrimeNumberHandler.CheckIfPrime(PrimeNumberHandler.FindNextPrime(rdn.Next(10000))));
            }

        }

        [Test]
        public void FindNextPrime_GiveSmallPrime_ReturnsNextSmallPrime()
        {

            Assert.AreEqual(7, PrimeNumberHandler.FindNextPrime(5));

        }

        [Test]
        public void FindNextPrime_GiveBigPrime_ReturnsNextBigPrime()
        {

            Assert.AreEqual(1000039, PrimeNumberHandler.FindNextPrime(1000037));

        }

    }
}
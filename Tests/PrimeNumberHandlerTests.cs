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
            PrimeHandler sut = new PrimeHandler();
            Assert.IsFalse(sut.CheckIfPrime(0));
            
        }

        [Test]
        public void CheckIfPrime_GivenOne_ReturnsFalse()
        {
            PrimeHandler sut = new PrimeHandler();
            Assert.IsFalse(sut.CheckIfPrime(1));

        }

        [Test]
        public void CheckIfPrime_GivenListOfSmallPrimeNumbers_ReturnsTrueForEveryNumber()
        {
            PrimeHandler sut = new PrimeHandler();
            List<int> smallPrimeNumbers = new List<int> { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37};
            
            foreach(int num in smallPrimeNumbers)
            {
                Assert.IsTrue(sut.CheckIfPrime(num));
            }
            
        }

        [Test]
        public void CheckIfPrime_GivenListOfBigPrimeNumbers_ReturnsTrueForEveryNumber()
        {
            PrimeHandler sut = new PrimeHandler();
            List<int> bigPrimeNumbers = new List<int> { 100057, 102233, 202481, 200899, 302563, 1000099 };

            foreach (int num in bigPrimeNumbers)
            {
                Assert.IsTrue(sut.CheckIfPrime(num));
            }

        }

        [Test]
        public void CheckIfPrime_GivenListOfCompositeNumbers_ReturnsFalseForEveryNumber()
        {
            PrimeHandler sut = new PrimeHandler();
            List<int> compositeNumbers = new List<int> { 4, 6, 8, 10, 20, 25, 30 };
            foreach (int num in compositeNumbers)
            {
                Assert.IsFalse(sut.CheckIfPrime(num));
            }
        }

        [Test]
        public void CheckIfPrime_GivenListOfNegativeCompositeNumbers_ReturnsFalseForEveryNumber()
        {
            PrimeHandler sut = new PrimeHandler();
            List<int> negativeCompositeNumbers = new List<int> { -4, -6, -8, -10, -20, -25, -30 };
            foreach (int num in negativeCompositeNumbers)
            {
                Assert.IsFalse(sut.CheckIfPrime(num));
            }
        }


        [Test]
        public void CheckIfPrime_GiveNegativeSmallPrimes_ReturnsFalseForEveryNumber()
        {
            PrimeHandler sut = new PrimeHandler();
            List<int> smallNegativePrimeNumbers = new List<int> { -2, -3, -5, -7, -11, -13, -17, -19, -23, -29, -31, -37 };

            foreach (int num in smallNegativePrimeNumbers)
            {
                Assert.IsFalse(sut.CheckIfPrime(num));
            }

        }

        [Test]
        public void CheckIfPrime_GiveNegativeBigPrimes_ReturnsFalseForEveryNumber()
        {
            PrimeHandler sut = new PrimeHandler();
            List<int> bigNegativePrimeNumbers = new List<int> { -100057, -102233, -202481, -200899, -302563, -1000099 };

            foreach (int num in bigNegativePrimeNumbers)
            {
                Assert.IsFalse(sut.CheckIfPrime(num));
            }

        }

        [Test]
        public void FindNextPrime_GiveSmallPrime_ReturnsNextSmallPrime()
        {
            PrimeHandler sut = new PrimeHandler();
            sut.CheckIfPrime(5);
            Assert.AreEqual(7, sut.FindNextPrime());
        }

        [Test]
        public void FindNextPrime_GiveBigPrime_ReturnsNextBigPrime()
        {
            PrimeHandler sut = new PrimeHandler();
            sut.CheckIfPrime(1000037);
            Assert.AreEqual(1000039, sut.FindNextPrime());
        }

    }
}
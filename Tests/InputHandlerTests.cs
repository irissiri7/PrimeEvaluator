using System;
using System.Collections.Generic;
using System.Text;
using Library;
using NUnit.Framework;

namespace Tests
{
    class InputHandlerTests
    {
        [Test]
        public void EvaluateInput_GivenCompositeNumber_ReturnsRightString()
        {
            PrimeHandler pnh = new PrimeHandler();
            Assert.AreEqual("No, that's not a prime number", InputHandler.CheckNumber("9", pnh));
        }

        [Test]
        public void EvaluateInput_GivenNegativeNumber_ReturnsRightString()
        {
            PrimeHandler pnh = new PrimeHandler();
            Assert.AreEqual("No, that's not a prime number", InputHandler.CheckNumber("-7", pnh));
        }

        [Test]
        public void EvaluateInput_GivenPrimeNumber_ReturnsRightString()
        {
            PrimeHandler pnh = new PrimeHandler();
            Assert.AreEqual("Yep, that's a prime number. It's added to the list", InputHandler.CheckNumber("5", pnh));
        }

        [Test]
        public void EvaluateInput_GivenPrimeNumber_AddsPrimeNumberToList()
        {
            PrimeHandler pnh = new PrimeHandler();
            InputHandler.CheckNumber("5", pnh);

            Assert.AreEqual(1, pnh.PrimeNumbers.Count);
            Assert.AreEqual(5, pnh.PrimeNumbers[0]);
        }

        [Test]
        public void EvaluateInput_GivenNextCommand_ReturnsRightString()
        {
            PrimeHandler pnh = new PrimeHandler();
            pnh.CheckIfPrime(5);
            Assert.AreEqual("The next prime number would be 7. We have added it to the list", InputHandler.PrintNextPrimeNumber(pnh));
        }

        [Test]
        public void EvaluateInput_GivenNextCommandWhenListIsEmpty_ReturnsRightString()
        {
            PrimeHandler pnh = new PrimeHandler();
            Assert.AreEqual("The list is empty, you must have at least one prime number in the list to use this function", InputHandler.PrintNextPrimeNumber(pnh));
        }


        [Test]
        public void EvaluateInput_GivenPrintCommand_ReturnsRightString()
        {
            PrimeHandler pnh = new PrimeHandler();
            pnh.CheckIfPrime(5);
            Assert.AreEqual("Current prime numbers: 5,", InputHandler.PrintPrimeNumberList(pnh));
        }

        [Test]
        public void EvaluateInput_GivenPrintCommandWhenListIsEmpty_ReturnsRightString()
        {
            PrimeHandler pnh = new PrimeHandler();
            Assert.AreEqual("The list is empty", InputHandler.PrintPrimeNumberList(pnh));
        }
    }
}

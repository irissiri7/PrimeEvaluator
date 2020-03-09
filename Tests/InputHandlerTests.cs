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
        public void EvaluateInput_GivenNull_ReturnsRightString()
        {
            PrimeNumberHandler pnh = new PrimeNumberHandler();
            Assert.AreEqual("You must give a command", InputHandler.EvaluateInput(null, pnh));
        }

        [Test]
        public void EvaluateInput_GivenInvalidCommand_ReturnsRightString()
        {
            PrimeNumberHandler pnh = new PrimeNumberHandler();
            Assert.AreEqual("Not a valid command, please try again", InputHandler.EvaluateInput("jdgufl+!..W", pnh));
        }

        [Test]
        public void EvaluateInput_GivenCompositeNumber_ReturnsRightString()
        {
            PrimeNumberHandler pnh = new PrimeNumberHandler();
            Assert.AreEqual("No, that's not a prime number", InputHandler.EvaluateInput("9", pnh));
        }

        [Test]
        public void EvaluateInput_GivenNegativeNumber_ReturnsRightString()
        {
            PrimeNumberHandler pnh = new PrimeNumberHandler();
            Assert.AreEqual("No, that's not a prime number", InputHandler.EvaluateInput("-7", pnh));
        }

        [Test]
        public void EvaluateInput_GivenPrimeNumber_ReturnsRightString()
        {
            PrimeNumberHandler pnh = new PrimeNumberHandler();
            Assert.AreEqual("Yep, that's a prime number. It's added to the list", InputHandler.EvaluateInput("5", pnh));
        }

        [Test]
        public void EvaluateInput_GivenPrimeNumber_AddsPrimeNumberToList()
        {
            PrimeNumberHandler pnh = new PrimeNumberHandler();
            InputHandler.EvaluateInput("5", pnh);

            Assert.AreEqual(1, pnh.PrimeNumbers.Count);
            Assert.AreEqual(5, pnh.PrimeNumbers[0]);
        }

        [Test]
        public void EvaluateInput_GivenNextCommand_ReturnsRightString()
        {
            PrimeNumberHandler pnh = new PrimeNumberHandler();
            pnh.CheckIfPrime(5);
            Assert.AreEqual("The next prime number would be 7. We have added it to the list", InputHandler.EvaluateInput("next", pnh));
        }

        [Test]
        public void EvaluateInput_GivenNextCommandWhenListIsEmpty_ReturnsRightString()
        {
            PrimeNumberHandler pnh = new PrimeNumberHandler();
            Assert.AreEqual("The list is empty, you must have at least one prime number in the list to use this function", InputHandler.EvaluateInput("next", pnh));
        }


        [Test]
        public void EvaluateInput_GivenPrintCommand_ReturnsRightString()
        {
            PrimeNumberHandler pnh = new PrimeNumberHandler();
            InputHandler.EvaluateInput("5", pnh);
            Assert.AreEqual("Current prime numbers: 5,", InputHandler.EvaluateInput("print", pnh));
        }

        [Test]
        public void EvaluateInput_GivenPrintCommandWhenListIsEmpty_ReturnsRightString()
        {
            PrimeNumberHandler pnh = new PrimeNumberHandler();
            Assert.AreEqual("The list is empty", InputHandler.EvaluateInput("print", pnh));
        }

        [Test]
        public void EvaluateInput_GivenNumberWithLotsOfWhiteSpace_RemovesAllWhitespaceAndPreformsPrimeEval()
        {
            PrimeNumberHandler pnh = new PrimeNumberHandler();
            Assert.AreEqual("Yep, that's a prime number. It's added to the list", InputHandler.EvaluateInput("   1    1", pnh));
        }
    }
}

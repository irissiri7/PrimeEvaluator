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
            List<int> temp = new List<int>();
            Assert.AreEqual("You must give a command", InputHandler.EvaluateInput(null, temp));
        }

        [Test]
        public void EvaluateInput_GivenInvalidCommand_ReturnsRightString()
        {
            List<int> temp = new List<int>();
            Assert.AreEqual("Not a valid command, please try again", InputHandler.EvaluateInput("jdgufl+!..W", temp));
        }

        [Test]
        public void EvaluateInput_GivenCompositeNumber_ReturnsRightString()
        {
            List<int> temp = new List<int>();
            Assert.AreEqual("No, that's not a prime number", InputHandler.EvaluateInput("9", temp));
        }

        [Test]
        public void EvaluateInput_GivenNegativeNumber_ReturnsRightString()
        {
            List<int> temp = new List<int>();
            Assert.AreEqual("No, that's not a prime number", InputHandler.EvaluateInput("-7", temp));
        }

        [Test]
        public void EvaluateInput_GivenPrimeNumber_ReturnsRightString()
        {
            List<int> temp = new List<int>();
            Assert.AreEqual("Yep, that's a prime number. It's added to the list", InputHandler.EvaluateInput("5", temp));
        }

        [Test]
        public void EvaluateInput_GivenPrimeNumber_AddsPrimeNumberToList()
        {
            List<int> temp = new List<int>();
            InputHandler.EvaluateInput("5", temp);

            Assert.AreEqual(1, temp.Count);
            Assert.AreEqual(5, temp[0]);
        }

        [Test]
        public void EvaluateInput_GivenNextCommand_ReturnsRightString()
        {
            List<int> temp = new List<int> { 2, 3, 5 };
            Assert.AreEqual("The next prime number would be 7. We have added it to the list", InputHandler.EvaluateInput("next", temp));
        }

        [Test]
        public void EvaluateInput_GivenNextCommandWhenListIsEmpty_ReturnsRightString()
        {
            List<int> temp = new List<int>();
            Assert.AreEqual("The list is empty, you must have at least one prime number in the list to use this function", InputHandler.EvaluateInput("next", temp));
        }


        [Test]
        public void EvaluateInput_GivenPrintCommand_ReturnsRightString()
        {
            List<int> temp = new List<int> { 2, 3, 5 };
            Assert.AreEqual("Current prime numbers: 2,3,5,", InputHandler.EvaluateInput("print", temp));
        }

        [Test]
        public void EvaluateInput_GivenPrintCommandWhenListIsEmpty_ReturnsRightString()
        {
            List<int> temp = new List<int>();
            Assert.AreEqual("The list is empty", InputHandler.EvaluateInput("print", temp));
        }

        [Test]
        public void EvaluateInput_GivenNumberWithLotsOfWhiteSpace_RemovesAllWhitespaceAndPreformsPrimeEval()
        {
            List<int> temp = new List<int>();
            Assert.AreEqual("Yep, that's a prime number. It's added to the list", InputHandler.EvaluateInput("   1    1", temp));
        }
    }
}

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
            List<int> temp = new List<int>();
            int updatedCurrentHighest;
            Assert.AreEqual("No, that's not a prime number", InputHandler.CheckNumber("9", temp, 0, out updatedCurrentHighest));
        }

        [Test]
        public void EvaluateInput_GivenNegativeNumber_ReturnsRightString()
        {
            List<int> temp = new List<int>();
            int updatedCurrentHighest;
            Assert.AreEqual("No, that's not a prime number", InputHandler.CheckNumber("-7", temp, 0, out updatedCurrentHighest));
        }

        [Test]
        public void EvaluateInput_GivenPrimeNumber_ReturnsRightString()
        {
            List<int> temp = new List<int>();
            int updatedCurrentHighest;
            Assert.AreEqual("Yep, that's a prime number. It's added to the list", InputHandler.CheckNumber("5", temp, 0, out updatedCurrentHighest));
        }

        [Test]
        public void EvaluateInput_GivenPrimeNumber_AddsPrimeNumberToList()
        {
            List<int> temp = new List<int>();
            int updatedCurrentHighest;
            InputHandler.CheckNumber("5", temp, 0, out updatedCurrentHighest);

            Assert.AreEqual(1, temp.Count);
            Assert.AreEqual(5, temp[0]);
        }

        [Test]
        public void EvaluateInput_GivenNextCommand_ReturnsRightString()
        {
            List<int> temp = new List<int>{ 5 };
            int updatedCurrentHighest;
            Assert.AreEqual("The next prime number would be 7. We have added it to the list", InputHandler.PrintNextPrimeNumber(5,temp, out updatedCurrentHighest));
        }

        [Test]
        public void EvaluateInput_GivenNextCommandWhenListIsEmpty_ReturnsRightString()
        {
            List<int> temp = new List<int>();
            int updatedCurrentHighest;
            Assert.AreEqual("The list is empty, you must have at least one prime number in the list to use this function", InputHandler.PrintNextPrimeNumber(0, temp, out updatedCurrentHighest));
        }


        [Test]
        public void EvaluateInput_GivenPrintCommand_ReturnsRightString()
        {
            List<int> temp = new List<int> { 5 };
            Assert.AreEqual("Current prime numbers: 5,", InputHandler.PrintPrimeNumberList(temp));
        }

        [Test]
        public void EvaluateInput_GivenPrintCommandWhenListIsEmpty_ReturnsRightString()
        {
            List<int> temp = new List<int>();
            Assert.AreEqual("The list is empty", InputHandler.PrintPrimeNumberList(temp));
        }
    }
}

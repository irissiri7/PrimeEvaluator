using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Library
{
    //This class is responsible for handling all the console input and communicating results to user. 
    public static class InputHandler
    {
        //PROPERTIES
        private static string Message { get; set; }

        //METHODS
        public static string CheckNumber(string input, List<int> primeNumbers, int currentHighest, out int currentHighestUpdated)
        {
            //Here we are making sure that the currentHighestUpdated per default is the currentHighest
            //so if the number we are evaluating is not prime or is lower than currentHighest, we will not actuallt change the currentHighest
            currentHighestUpdated = currentHighest;
            
            if (Int32.TryParse(input, out int num))
            {
                if (PrimeEvaluator.CheckIfPrime(num))
                {
                    Message = "Yep, that's a prime number. It's added to the list";
                    primeNumbers.Add(num);
                    if(num > currentHighest)
                    {
                        currentHighestUpdated = num;
                    }
                }
                else
                {
                    Message = "No, that's not a prime number";
                }
            }
            else
            {
                Message = "Not a valid number";
            }

            return Message;
        }

        public static string PrintPrimeNumberList(List<int> primeNumbers)
        {
            if (primeNumbers.Count == 0)
            {
                Message = "The list is empty";
            }
            else
            {
                //Using Stringbuilder to mimimize memory usage when building the string.
                StringBuilder strBld = new StringBuilder("Current prime numbers: ");
                foreach (int num in primeNumbers)
                {
                    strBld.Append(num + ",");
                }

                Message = strBld.ToString();
            }

            return Message;
        }

        public static string PrintNextPrimeNumber (int currentHighest, List<int> primeNumbers, out int currentHighestUpdate)
        {
            currentHighestUpdate = currentHighest;
            if (primeNumbers.Count == 0)
            {
                Message = "The list is empty, you must have at least one prime number in the list to use this function";
            }
            else
            {
                int next = PrimeEvaluator.FindNextPrime(currentHighest);
                primeNumbers.Add(next);
                currentHighestUpdate = next;
                Message = $"The next prime number would be {next}. We have added it to the list";
            }

            return Message;
        }

       
    }
}

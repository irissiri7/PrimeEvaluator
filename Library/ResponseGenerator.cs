using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Library
{
    //This class is responsible for generating correct response to the user depending on the input and the results from PrimeEvaluator.cs
    public static class ResponseGenerator
    {
        //PROPERTIES
        private static string Message { get; set; }

        //METHODS
        public static string CheckNumber(string input, List<int> primeNumbers, int currentHighestPrime, out int updatedCurrentHighestPrime)
        {
            //Here we are making sure that the updatedCurrentHighestPrime per default is the currentHighestPrime. It will only change
            //if it turns out the num we are evaluating is both prime and higher.
            updatedCurrentHighestPrime = currentHighestPrime;
            
            if (Int32.TryParse(input, out int num))
            {
                if (PrimeEvaluator.CheckIfPrime(num))
                {
                    Message = "Yep, that's a prime number. It's added to the list";
                    primeNumbers.Add(num);
                    if(num > currentHighestPrime)
                    {
                        updatedCurrentHighestPrime = num;
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
            //Again, making sure that the default value is the current highest prime.
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

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
        public static string CheckNumber(string input, PrimeHandler pnh)
        {
            
            if (Int32.TryParse(input, out int num))
            {
                if (pnh.CheckIfPrime(num))
                {
                    Message = "Yep, that's a prime number. It's added to the list";
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

        public static string PrintPrimeNumberList(PrimeHandler pnh)
        {
            if (pnh.PrimeNumbers.Count == 0)
            {
                Message = "The list is empty";
            }
            else
            {
                //Using Stringbuilder to mimimize memory usage when building the string.
                StringBuilder strBld = new StringBuilder("Current prime numbers: ");
                foreach (int num in pnh.PrimeNumbers)
                {
                    strBld.Append(num + ",");
                }

                Message = strBld.ToString();
            }

            return Message;
        }

        public static string PrintNextPrimeNumber (PrimeHandler pnh)
        {
            if (pnh.PrimeNumbers.Count == 0)
            {
                Message = "The list is empty, you must have at least one prime number in the list to use this function";
            }
            else
            {
                int next = pnh.FindNextPrime();
                Message = $"The next prime number would be {next}. We have added it to the list";
            }

            return Message;
        }

       
    }
}

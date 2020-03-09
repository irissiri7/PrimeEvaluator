using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Library
{
    //This class is responsible for handling all the console input and communicating results to user. 
    //It can handle numbers, 'print', 'next' and 'e' commands. Everyting else is considered not a valid command.
    public static class InputHandler
    {

        public static string EvaluateInput(string inputRaw, List<int> currentPrimes)
        {
            string output;
     
            //It should not be possible to send 'null' since Console.ReadLine will interpret 
            //everyting as a string (empty or not). But it turned out you can
            //send in 'null' if you start the application, press F6 and then press 'Enter'. Then input == 'null'
            //and the application crashes. Since we never want the program to crash due to user input (merely it
            //should ignore all invalid input) we have this check.
            if (inputRaw == null)
            {
                output = "You must give a command";
            }
            else
            {
                //Using Regex to remove any white space, so if the user for some reason has written '    1   1', the
                //program will interpret it as '11' or 'n   e   x   t' will be interpreted as 'next'. 
                //Also adding .ToLower() to all input so the program is not 
                //case sensitive to valid commands.
                string input = Regex.Replace(inputRaw, @"\s+", "").ToLower();
                
                if (input == "next")
                {
                    //Since we must know current highest number to find the next one, we give this message to user if
                    //list is empty.
                    if (currentPrimes.Count == 0)
                    {
                        output = "The list is empty, you must have at least one prime number in the list to use this function";
                    }
                    else
                    {
                        //Retriving the current highest prime number in list with Linq .Max() method.
                        int num = currentPrimes.Max();
                        int next = PrimeNumberHandler.FindNextPrime(num);
                        currentPrimes.Add(next);
                        output = "The next prime number would be " + next + ". We have added it to the list";
                    }
                }
                else if (input == "print")
                {
                    //Same here, can not execute command if list is empty.
                    if (currentPrimes.Count == 0)
                    {
                        output = "The list is empty";
                    }
                    else
                    {
                        //Using Stringbuilder to mimimize memory usage when building the string.
                        StringBuilder strBld = new StringBuilder("Current prime numbers: ");
                        foreach(int num in currentPrimes)
                        {
                            strBld.Append(num + ",");
                        }

                        return strBld.ToString();
                    }
                }
                //If we can parse it as an Int32 we will evaluate it
                else if(Int32.TryParse(input, out int num))
                {
                    if (PrimeNumberHandler.CheckIfPrime(num))
                    {
                        output = "Yep, that's a prime number. It's added to the list";
                        currentPrimes.Add(num);
                    }
                    else
                    {
                        output = "No, that's not a prime number";
                    }
                }
                //Everyting elese is considered not a valid command.
                else
                {
                    output = "Not a valid command, please try again";
                }
            }

            return output;
        }
       
    }
}

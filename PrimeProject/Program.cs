using System;
using System.Collections.Generic;
using Library;

namespace PrimeProject
{
    class Program
    {
        static void Main(string[] args)
        {
            //Instructions for player
            Console.WriteLine("Welcome to this Prime Number Application");
            Console.WriteLine("Type any number between 0 and 2'147'483'647 and we will tell you wheather it is a prime number or not");
            Console.WriteLine("If it is a prime number we will also add it to a list");
            Console.WriteLine("If you would like to see the contents of the list, type 'print'");
            Console.WriteLine("If you would like to get a suggestion of the next prime number (compared to the highest prime number you have so far in the list), type 'next' and we will add it to your list");
            Console.WriteLine("Type 'e' to quit the application");

            //List to store given numbers
            List<int> primeNumbers = new List<int>();

            //Game loop
            bool running = true;
            while (running)
            {
                Console.WriteLine("Choose a command");
                string input = Console.ReadLine();
                if (input == "e")
                {
                    Console.WriteLine("Bye bye!");
                    running = false;
                }
                else
                {
                    Console.WriteLine(InputHandler.EvaluateInput(input, primeNumbers));
                }

            }


        }


    }

}

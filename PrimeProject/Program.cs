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
            Console.WriteLine("Welcome!");
            Console.WriteLine("This application can evaluate any number between 0 and 2'147'483'647 and tell you if it is prime or not.");
            Console.WriteLine("All the prime numbers are saved in a list. You can reffer to the list any time you want.");
            Console.WriteLine("Your can also get suggestion of next prime number, compared to the current highest prime number in the list.");
            Console.WriteLine("[1] Evaluate number");
            Console.WriteLine("[2] Print prime number list");
            Console.WriteLine("[3] Suggest next prime number");
            Console.WriteLine("[4] Exit");

            PrimeNumberHandler pnh = new PrimeNumberHandler();

            //Game loop
            bool running = true;
            while (running)
            {
                Console.Write(">>");
                string input = Console.ReadLine();
                if (input == "4")
                {
                    Console.WriteLine("Bye bye!");
                    running = false;
                }
                else
                {
                    Console.WriteLine(InputHandler.EvaluateInput(input, pnh));
                }

            }


        }


    }

}

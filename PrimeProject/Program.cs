using System;
using System.Collections.Generic;
using Library;

namespace PrimeProject
{
    class Program
    {
        //PROPERTIES
        //I have choosen to save the current highest prime in a property so I don't have to search for it in the PrimeNumbers list.
        //Searching in Lists can be a time consuming process (at least if the list is long - O(n)). This way, the time
        //complexity for finding the current highest prime number is constant. Keeping this number updated is easy and won't
        //compromise performance of application.
        public static int CurrentHighestPrime { get; private set; } = 0;
        public static List<int> PrimeNumbers { get; private set; } = new List<int>();
        
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

            //Game loop
            bool running = true;
            while (running)
            {
                Console.Write(">>");
                string input = Console.ReadLine();

                //Some methods return a new updated value for CurrentHighestPrime. This variable catches these values and is used to update the
                //property accordingly.
                int updatedCurrentHighestPrime;
                
                switch (input)
                {
                    case "1":
                        Console.WriteLine("Type a number");
                        input = Console.ReadLine();
                        Console.WriteLine(ResponseGenerator.CheckNumber(input, PrimeNumbers, CurrentHighestPrime, out updatedCurrentHighestPrime));
                        CurrentHighestPrime = updatedCurrentHighestPrime;
                        break;
                    case "2":
                        Console.WriteLine(ResponseGenerator.PrintPrimeNumberList(PrimeNumbers));
                        break;
                    case "3":
                        Console.WriteLine(ResponseGenerator.PrintNextPrimeNumber(CurrentHighestPrime, PrimeNumbers, out updatedCurrentHighestPrime));
                        CurrentHighestPrime = updatedCurrentHighestPrime;
                        break;
                    case "4":
                        Console.WriteLine("Bye bye!");
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid command");
                        break;
                }

            }


        }


    }

}


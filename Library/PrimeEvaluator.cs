using System;
using System.Collections.Generic;

namespace Library
{
    //This class is responsible for evaluating prime numbers.
    public static class PrimeEvaluator
    {
        
        public static bool CheckIfPrime(int n)
        {
            //Assuming it is prime
            bool isPrime = true;
            
            //If negative number, 0 or 1 it is automatically not prime since they are not considered to be
            if (n < 0 || n == 0 || n == 1)
            {
                isPrime = false;
            }
            else
            {
                //Here we are looping between 2 and 'n' to determine if the number can be evenly divided
                //with any other number between 2 and 'n'. If it can it is NOT prime and result becomes false.
                for (int i = 2; i < n - 1; i++)
                {
                    if (n % i == 0)
                    {
                        isPrime = false;
                    }
                }
            }

            return isPrime;
        }

        public static int FindNextPrime(int n)
        {
            bool status = false;
            
            //'n' represents the value of the current highest prime.
            int nextPrime = n;

            //In this loop we are continuously increasing the 'nextPrime' by 1 until it passes our function
            //CheckIfPrime(). When it does we have found the next prime number.
            while (!status)
            {
                nextPrime++;
                status = CheckIfPrime(nextPrime);
            }

            return nextPrime;
        }
       
    }
}

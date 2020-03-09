using System;

namespace Library
{
    //This class is responsible for evaluating prime numbers.
    public static class PrimeNumberHandler
    {
        public static bool CheckIfPrime(int n)
        {
            //Assuming it is prime
            bool result = true;
            
            //If negative number, zero or one it is automatically not prime since they are not considered to be
            if (n < 0 || n == 0 || n == 1)
            {
                result = false;
            }
            else
            {
                //Here we are looping between 2 and 'n' to determine if the number can be evenly divided
                //with any other number between 2 and 'n'. If it can it is not prime and result becomes false.
                for (int i = 2; i < n - 1; i++)
                {
                    if (n % i == 0)
                    {
                        result = false;
                    }
                }
            }
            
            return result;
        }

        public static int FindNextPrime(int n)
        {
            bool status = false;
            
            //Variable that will become the next prime number. Parameter 'n' represents the current 
            //highest prime number in the list
            int nextPrime = n;

            //In this loop we are continuously increasing the 'nextPrime' by 1 until it passes our function
            //CheckIfPrime(). When it does we have found te next prime number.
            while (!status)
            {
                nextPrime++;
                status = CheckIfPrime(nextPrime);
            }

            return nextPrime;
        }
    }
}

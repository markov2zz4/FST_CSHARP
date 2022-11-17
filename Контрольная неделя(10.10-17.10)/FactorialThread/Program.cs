using System;
using System.Numerics;
using System.Threading;

namespace FactorialThread
{
    class Program
    {
        static void Main()
        {
            Console.Write("Enter a number: ");

            int number = Convert.ToInt32(Console.ReadLine());
            int number_threads = number;

            Console.WriteLine($"Number will be split into {number_threads} threads");
            BigInteger[] bigIntegers = new BigInteger[number_threads + 2];


            for (int i = 0; i < bigIntegers.Length; i++)
                bigIntegers[i] = 1;


            Thread[] threads = new Thread[number_threads + 1];

            Console.WriteLine("Calculating...");

            for (int i = 0; i < threads.Length; i++)
            {
                int start = i * number_threads + 1;
                int end = (i + 1) * number_threads;

                if (end > number)
                    end = number;


                threads[i] = new Thread(() => { bigIntegers[i] = Factorial(start, end); });
                threads[i].Start();
            }

            for (int i = 0; i < threads.Length; i++)
                threads[i].Join();


            Console.WriteLine("Threads is done");

            BigInteger result = 1;
            for (int i = 0; i < bigIntegers.Length; i++)
                result *= bigIntegers[i];

           Console.WriteLine("\nResult: " + result);
        }

        static BigInteger Factorial(int first, int second)
        {
            BigInteger result = 1;
            for (int i = first; i <= second; i++)
                result *= i;

            return result;

        }
    }
}
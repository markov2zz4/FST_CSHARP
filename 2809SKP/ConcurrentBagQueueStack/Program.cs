using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System.Numerics;

//factorial 1.(Bigint)
//2. Concurrent collections
//3. ThreadPool

namespace ConcurrentBagQueueStack
{
    /*
    class Program
    {

        static BigInteger factorial(uint num)
        {
            if (num == 0)
                return 1;

            BigInteger result = 1;

            for (uint i = 1; i <= num; i++)
                result *= i;

            return result;
        }

        static void Main()
        {
            Console.WriteLine(factorial(4));
        }
    }
    */
    class ConcurrentBagDemo
    {
        // Demonstrates:
        //      ConcurrentBag<T>.Add()
        //      ConcurrentBag<T>.IsEmpty
        //      ConcurrentBag<T>.TryTake()
        //      ConcurrentBag<T>.TryPeek()
        static void Main()
        {
            Console.WriteLine("Enter num: ");
            int number = Convert.ToInt32(Console.ReadLine());
            
            

            ConcurrentBag<int> cb = new ConcurrentBag<int>();
            for (int i = number; i > 0; i--)
            {
                cb.Add(i);
                Console.WriteLine();
            }



            BigInteger result = 1;



            int unexpectedItem;
            if (cb.TryPeek(out unexpectedItem))
                Console.WriteLine("Found an item in the bag when it should be empty");
        }
    }
}

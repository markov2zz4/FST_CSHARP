using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Fucktorial
{
    public static class FactorialExtensions
    {
        public static BigInteger Factorial(this int n)
        {
            var result = BigInteger.One;
            for (BigInteger i = 2; i <= n; i++) result *= i;
            return result;
        }

        public static BigInteger ThreadFactorial(this int n, int proc = 0)
        {
            if (n <= 1) return BigInteger.One;
            if (proc == 0) proc = Environment.ProcessorCount;
            if (proc <= 1 || n <= proc) return n.Factorial();

            Thread[] threads = new Thread[proc];

            var results = new ConcurrentBag<BigInteger>();


            for (int i = 0; i < threads.Length; i++)
            {
                var k = i;
                threads[i] = new Thread(() =>
                {
                    var res = BigInteger.One;
                    for (int j = k + 1; j <= n; j += proc) res *= j;
                    results.Add(res);
                });
                threads[i].Start();
            }

            foreach (var thread in threads) thread.Join();

            return results
                .AsParallel()
                .Aggregate((i, j) => i * j);
        }

        public static BigInteger TaskFactorial(this int n, int proc = 0)
        {
            if (n <= 1) return BigInteger.One;
            if (proc == 0) proc = Environment.ProcessorCount;
            if (proc <= 1 || n <= proc) return n.Factorial();

            Task[] tasks = new Task[proc];

            var results = new ConcurrentBag<BigInteger>();
            var running = n / proc < 100000 ? TaskCreationOptions.LongRunning : TaskCreationOptions.None;
            var fabric = new TaskFactory();



            for (int i = 0; i < tasks.Length; i++)
            {
                var k = i;
                tasks[i] = fabric.StartNew(() =>
                {
                    var res = BigInteger.One;
                    for (int j = k + 1; j <= n; j += proc) res *= j;
                    while (results.TryTake(out var take)) res *= take;
                    results.Add(res);
                }, running);
            }

            Task.WaitAll(tasks);

            return results
                .AsParallel()
                .Aggregate((i, j) => i * j);
        }

        public static BigInteger ParallelForFactorial(this int n, int proc = 0)
        {
            if (n <= 1) return BigInteger.One;
            if (proc == 0) proc = Environment.ProcessorCount;
            if (proc <= 1 || n <= proc) return n.Factorial();


            var results = new ConcurrentBag<BigInteger>();
            Parallel.For(1, proc + 1, i =>
            {
                var res = BigInteger.One;
                for (int j = i; j <= n; j += proc) res *= j;
                while (results.TryTake(out var take)) res *= take;
                results.Add(res);
            });

            return results
                .AsParallel()
                .Aggregate((i, j) => i * j);
        }
    }
}

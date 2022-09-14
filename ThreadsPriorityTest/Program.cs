using System;
using System.Threading;

namespace ThreadsPriorityTest
{
    class Program
    {
        static void Main(string[] args)
        {
            

            Writer writer1 = new Writer('-');
            Writer writer2 = new Writer('+');
            Thread thread2 = new Thread(writer2.WriteChars)
            {
                Priority = ThreadPriority.Highest
            };

            Thread.CurrentThread.Priority = ThreadPriority.Lowest;

            thread2.Start();
            writer1.WriteChars();
            Console.WriteLine($"\nPrimary: {writer1.Counter} - ");
            Console.WriteLine($"\nSecondary: {writer2.Counter} + ");
            Console.WriteLine($"\nTogether: {Interlocked.Read(ref Writer.GlobalCounter)}");
        }
    }
}

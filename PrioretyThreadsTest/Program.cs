using System;
using System.Diagnostics;
using System.Threading;

namespace PrioretyThreadsTest
{
    class Program
    {
        static void Main()
        {

            object obj = new object();
            Writer writer = new Writer('-');
            Writer writer2 = new Writer('+');
            Thread thread2 = new Thread(writer2.WriteChars)
            {
                Priority = ThreadPriority.Highest
            };
            Thread.CurrentThread.Priority = ThreadPriority.Lowest;
            thread2.Start();
            writer.WriteChars();
            Console.WriteLine($"\nПервичный поток написал {writer.Counter} -");
            Console.WriteLine($"\nВторичный поток написал {writer2.Counter} +");
            //Console.WriteLine($"\nПотоки написали {Writer.GlobalCounter} символов");
            Console.WriteLine($"\nПотоки написали {Interlocked.Read(ref Writer.GlobalCounter)} символов");
            
        }
    }

}

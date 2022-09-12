using System;
using System.Threading;

object locker = new object();
long counter = 100;

void WriteSecond()
{
    
    for (int i = 0; i < 20; i++)
    {
        
        lock (locker)
        {
            counter = 0;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"{new string(' ', 10)}Secondary: {counter}" );
            Console.ForegroundColor = ConsoleColor.Gray;

            Thread.Sleep(100);
        }
    }
      
}
ThreadStart writeSecond = WriteSecond;
Thread thread = new Thread(writeSecond);
thread.Start();


for (int i = 0; i < 20; i++)
{
    lock (locker)
    {
        counter = 100;
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"Primary: {counter}");
        Console.ForegroundColor = ConsoleColor.Gray;

        Thread.Sleep(100);
    }
}



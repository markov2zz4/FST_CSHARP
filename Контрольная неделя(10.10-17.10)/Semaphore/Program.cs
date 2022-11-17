using System;
using System.Threading;

public class Example
{
    class Reader
    {
        // создаем семафор
        static Semaphore sem = new Semaphore(3, 5);
        Thread myThread;

        public Reader(int i)
        {
            myThread = new Thread(Eat);
            myThread.Name = $"Философ {i}";
            myThread.Start();
        }

        public void Eat()
        {
            sem.WaitOne(); // ожидаем, когда освободиться место

            Console.WriteLine($"{Thread.CurrentThread.Name} садится за стол");

            Thread.Sleep(3000);

            Console.WriteLine($"{Thread.CurrentThread.Name} выходит из-за стола");

            sem.Release(); // освобождаем место
        }

        static void Main(string[] args)
        {
            for (int i = 3; i < 11; i++)
            {
                Reader reader = new Reader(i);
            }
            Thread.Sleep(1000);
            Console.WriteLine("Первый философ покушал");
            sem.Release();
            Thread.Sleep(1000);
            Console.WriteLine("Второй философ покушал");
            sem.Release();
        }
    }
}

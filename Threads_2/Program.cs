using System;
using System.Threading;

Thread thread1 = new Thread(() =>
{
    while (true) Console.WriteLine("Primary");
});

thread1.IsBackground = true;
thread1.Start();

Thread.Sleep(10000);

/*
 * Сделать 
 */

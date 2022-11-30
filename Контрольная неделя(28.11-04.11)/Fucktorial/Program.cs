using System;
using System.Diagnostics;
using System.Threading;
using Fucktorial;

void printTime(Stopwatch sw)
{
    TimeSpan ts = sw.Elapsed;
    string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
        ts.Hours, ts.Minutes, ts.Seconds,
        ts.Milliseconds / 10);
    Console.WriteLine("RunTime " + elapsedTime);

}

Stopwatch stopWatch = new Stopwatch();
Stopwatch stopWatch_2 = new Stopwatch();
Stopwatch stopWatch_3 = new Stopwatch();

stopWatch.Start();
100000.ThreadFactorial();
stopWatch.Stop();

printTime(stopWatch);


stopWatch_2.Start();
100000.TaskFactorial();
stopWatch_2.Stop();

printTime(stopWatch_2);

stopWatch_3.Start();
100000.ParallelForFactorial();
stopWatch_3.Stop();

printTime(stopWatch_3);
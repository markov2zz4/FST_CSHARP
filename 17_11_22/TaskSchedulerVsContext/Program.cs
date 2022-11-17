using System;
using System.Threading;
using System.Threading.Tasks;

namespace TaskSchedulerVsContext
{
    class Program
    {

        static Program()
        {
            SynchronizationContext.SetSynchronizationContext(new ThreadSyncContext());
        }

        static void Work(Object _)
        {
            Thread.Sleep(1000);
            Console.WriteLine($"The method Work has finished its work in {Thread.CurrentThread.ManagedThreadId} thread");
        }

        static async Task WorkAsync(Object _)
        {
            await Task.Delay(1000);
            Console.WriteLine($"The method WorkAsync has finished its work in {Thread.CurrentThread.ManagedThreadId} thread in context {TaskScheduler.FromCurrentSynchronizationContext()}");
        }

        static async Task Main(string[] args)
        {
            TaskScheduler scheduler = new ThreadTaskScheduler();
            Task t1 = new Task(Work, null);

            //t1.Start();
            //t1.Start(scheduler);
            //t1.Start(TaskScheduler.Current);
            //t1.Start(TaskScheduler.FromCurrentSynchronizationContext());
            //await WorkAsync(null).ConfigureAwait(false);            

            Console.ReadKey();
        }
    }
}

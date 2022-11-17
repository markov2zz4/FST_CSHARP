using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;


namespace TaskSchedulerVsContext
{
    class ThreadSyncContext : SynchronizationContext
    {
        public override void Post(SendOrPostCallback d, object state)
        {
            Console.WriteLine("It's ThreadTaskScheduler - Post");
            new Thread(() => d.Invoke(state)).Start();
        }

        public override void Send(SendOrPostCallback d, object state)
        {
            Console.WriteLine("It's ThreadTaskScheduler - Send");
            d.Invoke(state);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace TaskSchedulerVsContext
{
    class ThreadTaskScheduler : TaskScheduler
    {
        protected override IEnumerable<Task> GetScheduledTasks()
        {
            return Enumerable.Empty<Task>();
        }

        protected override void QueueTask(Task task)
        {
            Console.WriteLine("It's ThreadTaskScheduler - QueueTask");
            new Thread(() => TryExecuteTask(task)).Start();
        }

        protected override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued)
        {
            Console.WriteLine("It's ThreadTaskScheduler - TryExecuteTaskInline");
            return TryExecuteTask(task); 
        }
    }
}

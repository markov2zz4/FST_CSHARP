using System;
using System.Threading;

class TimerExample
{
    static void Main()
    {

        var autoEvent = new AutoResetEvent(false);

        var statusChecker = new StatusChecker(10);

        var stateTimer = new Timer(statusChecker.CheckStatus,
                                   autoEvent, 0, 1000);

        autoEvent.WaitOne();
        stateTimer.Change(0, 500);

        autoEvent.WaitOne();
        stateTimer.Dispose();
    }
}

class StatusChecker
{
    private int invokeCount;
    private int maxCount;

    public StatusChecker(int count)
    {
        invokeCount = 0;
        maxCount = count;
    }
    public void CheckStatus(Object stateInfo)
    {
        AutoResetEvent autoEvent = (AutoResetEvent)stateInfo;
        Console.WriteLine(DateTime.Now);
        Console.SetCursorPosition(0, 0);
    }
}
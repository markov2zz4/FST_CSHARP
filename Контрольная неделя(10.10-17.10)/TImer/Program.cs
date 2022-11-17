using System;
using System.Threading;

class MyTimer
{
    static void Main()
    {
        Console.CursorVisible = false;

        var autoEvent = new AutoResetEvent(false);

        var statusChecker = new StatusChecker();

        var stateTimer = new Timer(statusChecker.CheckStatus, autoEvent, 1000, 250);

        autoEvent.WaitOne();
    }
}

class StatusChecker
{

    public StatusChecker()
    {
    }

    public void CheckStatus(Object stateInfo)
    {
        Console.SetCursorPosition(0, 0);
        Console.WriteLine(DateTime.Now.ToString("h:mm:ss"));
    }
}   
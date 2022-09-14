using System;
using System.Diagnostics;
using System.Threading;

namespace PrioretyThreadsTest
{

    public class Writer
    {
        public static long GlobalCounter = 0;
        private const int Span = 2*1000 ;
        private char _symbol;
        private readonly Stopwatch timeInterval = new Stopwatch();
        public int Counter { get; private set; }

        public Writer(char symbol)
        {
            this._symbol = symbol;
        }

        public void WriteChars()
        {
            timeInterval.Restart();
            do
            {
                //Console.Write(_symbol);
                Counter++;
                Interlocked.Increment(ref GlobalCounter);
            }
            while (timeInterval.ElapsedMilliseconds < Span);
        }

    }

}

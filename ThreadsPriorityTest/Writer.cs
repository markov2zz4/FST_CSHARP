using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Threading;

namespace ThreadsPriorityTest
{
    class Writer
    {
        public static long GlobalCounter;
        private const int SPAN = 2 * 1000;
        private char symbol;

        private readonly Stopwatch timeInterval = new Stopwatch();

        public int Counter { get; private set; }

        public Writer(char symbol) {
            this.symbol = symbol;
        }
        public void WriteChars()
        {
            timeInterval.Restart();
            do
            {
                //Console.Write(symbol);
                Counter++;
                Interlocked.Increment(ref GlobalCounter);
            }
            while (timeInterval.ElapsedMilliseconds < SPAN);
        }
    }
}
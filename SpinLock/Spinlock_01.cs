using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace SpinLock
{
    class Spinlock_01
    {
        private SpinLock _spinLock = new SpinLock();

        public void DoWork()
        {
            bool lockTaken = false;
            try
            {
                _spinLock.Enter(ref lockTaken);
                // do work here protected by the lock  
            }
            finally
            {
                if (lockTaken) _spinLock.Exit();
            }
        }
    }
}

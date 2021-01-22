using SimpleThreadLock.Abstracts;
using System;
using System.Runtime.CompilerServices;
using System.Threading;

namespace SimpleThreadLock.Codes
{
    public class Counting : ITestCode
    {
        public void TestRun()
        {
            Counter counter = new Counter();

            Thread t1 = new Thread(() => RunCounter(counter));
            Thread t2 = new Thread(() => RunCounter(counter));

            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();

            Console.Out.WriteLine("Final Count = [{0}]", counter.Count);
        }

        private void RunCounter(Counter counter)
        {
            for (int index = 0; index < 10000; index++)
            {
                counter.Increment();
            }
        }
        
        internal class Counter
        {
            private int _count = 0;

            public int Count
            {
                get { return this._count; }
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            public void Increment()
            {
                ++this._count;
            }
        }
    }
}

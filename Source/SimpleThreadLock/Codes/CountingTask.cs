using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace SimpleThreadLock.Codes
{
    public class CountingTask
    {
        public void TestRun()
        {
            Counter counter = new Counter();

            Task t1 = new Task(() => RunCounter(counter));
            Task t2 = new Task(() => RunCounter(counter));

            t1.Start();
            t2.Start();

            t1.Wait();
            t2.Wait();

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

            // [MethodImpl(MethodImplOptions.Synchronized)]
            public void Increment()
            {
                ++this._count;
            }
        }
    }
}

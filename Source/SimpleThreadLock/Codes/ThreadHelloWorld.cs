using SimpleThreadLock.Abstracts;
using System;
using System.Threading;

namespace SimpleThreadLock.Codes
{
    public class ThreadHelloWorld: ITestCode
    {
        public void TestRun()
        {
            Thread myThread = new Thread(
                () => { Console.Out.WriteLine("Hello from new thread!!!"); }
            );

            myThread.Start();
            Thread.Yield();
            //Thread.Sleep(1);

            Console.Out.WriteLine("Hello from main thread!!!");
            myThread.Join();
        }
    }
}

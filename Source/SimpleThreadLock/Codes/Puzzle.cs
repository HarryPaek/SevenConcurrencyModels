using SimpleThreadLock.Abstracts;
using System;
using System.Threading;

namespace SimpleThreadLock.Codes
{
    public class Puzzle : ITestCode
    {
        private bool answerReady = false;
        private int answer = 0;

        public void TestRun()
        {
            Thread t1 = new Thread(
                () => {
                    answer = 42;
                    answerReady = true;
                }
            );

            Thread t2 = new Thread(
                () => {
                    if(answerReady)
                        Console.Out.WriteLine("The Meaning of Answer is [{0}]", answer);
                    else
                        Console.Out.WriteLine("I don't know the answer.");
                }
            );

            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();
        }
    }
}

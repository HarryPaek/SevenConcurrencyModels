using SimpleThreadLock.Abstracts;
using System;
using System.Threading.Tasks;

namespace SimpleThreadLock.Codes
{
    public class PuzzleTask: ITestCode
    {
        private bool answerReady = false;
        private int answer = 0;

        public void TestRun()
        {
            Task t1 = new Task(
                () => {
                    answer = 42;
                    answerReady = true;
                }
            );

            Task t2 = new Task(
                () => {
                    if (answerReady)
                        Console.Out.WriteLine("The Meaning of Answer is [{0}]", answer);
                    else
                        Console.Out.WriteLine("I don't know the answer.");
                }
            );

            t1.Start();
            t2.Start();

            t1.Wait();
            t2.Wait();
        }
    }
}

using SimpleThreadLock.Codes;
using System;

namespace SimpleThreadLock
{
    class Program
    {
        static void Main(string[] args)
        {
            // new ThreadHelloWorld().TestRun();
            // RunCounting();
            RunPuzzle();

            Console.In.ReadLine();
        }

        private static void RunPuzzle()
        {
            for (int index = 0; index < 3000; index++)
            {
                // new Puzzle().TestRun();
                new PuzzleTask().TestRun();
            }
        }

        private static void RunCounting()
        {
            for (int index = 0; index < 1000; index++)
            {
                // new Counting().TestRun();
                new CountingTask().TestRun();
            }
        }
    }
}

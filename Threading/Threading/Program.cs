using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threading
{
    class Program
    {
        public static void ThreadMethod()
        {
            for (int i=0; i<10; i++)
            {
                Console.WriteLine("ThreadProc: {0}", i);
            }
        }
        static void Main(string[] args)
        {
            Thread t = new Thread(new ThreadStart(ThreadMethod));
            t.Start();
            for (int i=0; i<4; i++)
            {
                Console.WriteLine("Main thread: Do some Work");
                Thread.Sleep(0);
            }
            t.Join();
            parallelTest();
        }

        public static async void parallelTest()
        {
            Parallel.For(0, 10, i =>
            {
                Console.WriteLine("2: " + i);
                Thread.Sleep(0);
            });
            var numbers = Enumerable.Range(0, 10);

            Parallel.ForEach(numbers, i =>
            {
                Console.WriteLine("1: " + i);
                Thread.Sleep(0);
            });

        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace Threads
{
    public class ClassTask
    {
        static readonly Random rnd = new Random();
        static decimal sumThreads = 0;
        static decimal sum = 0;
        static readonly decimal[] array = new decimal[1000000];
        public static void Class()
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rnd.Next(0, 1000);
            }
            var sw = Stopwatch.StartNew();
            foreach (var i in array)
            {
                sum += i;
            }
            Console.WriteLine("sum 1 thread - " + sum);
            sw.Stop();
            Console.WriteLine("1 thread - " + sw.ElapsedMilliseconds);

            var sw2 = Stopwatch.StartNew();
            Thread sumThread = new Thread(SumFunc);
            Thread sumThread2 = new Thread(SumFunc2);
            sumThread.Start();
            sumThread2.Start();

            sumThread.Join();
            sumThread2.Join();

            sw2.Stop();
            Console.WriteLine("2 threads - " + sw2.ElapsedMilliseconds);

            Console.WriteLine("Linq sum - " + array.Sum());
            Console.WriteLine("Linq count - " + array.Count());
        }

        private static void SumFunc()
        {
            for (int i = 0; i < array.Length / 2; i++)
            {
                sumThreads += array[i];
            }
            Console.WriteLine("Sum thread 1 - " + sumThreads);
        }
        private static void SumFunc2()
        {
            for (int i = array.Length / 2; i < array.Length; i++)
            {
                sumThreads += array[i];
            }
            Console.WriteLine("Sum thread 2 - " + sumThreads);
        }
    }

}

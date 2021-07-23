using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace Threads
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = ThreadingTask.CreateAndFillArray(7777);
            var copiedArray = ThreadingTask.CreateAndCopyArray(array, 7, 77);
            var minNumber = ThreadingTask.GetArrayMin(array);
            var averageNumber = ThreadingTask.GetArrayAverage(array);

            Console.WriteLine("Array");
            foreach (var number in array)
            {
                Console.Write($"{number} ");
            }
            Console.WriteLine("\n\nCopied Array");
            foreach (var number in copiedArray)
            {
                Console.Write($"{number} ");
            }
            Console.WriteLine($"\n\nMinimum - {minNumber}");
            Console.WriteLine($"\nAverage - {averageNumber.ToString("F" + 7)}");
        }
    }
}

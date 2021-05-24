using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Threads
{
    public static class ThreadingTask
    {
        static readonly int proccessors = Environment.ProcessorCount;
        static readonly Thread[] threads = new Thread[proccessors];

        public static void Execute(ParameterizedThreadStart parameterizedThreadStart, Data data)
        {
            for (int threadNumber = 0; threadNumber < proccessors; threadNumber++)
            {
                threads[threadNumber] = new Thread(parameterizedThreadStart);

                var tempData = new Data()
                {
                    Array = data.Array,
                    Start = (data.Start == null) ? threadNumber * data.Array.Length / proccessors : data.Start,
                    End = (data.End == null) ? (threadNumber + 1) * data.Array.Length / proccessors : data.End,
                    IntermediateArray = data.IntermediateArray,
                    Indent = (data.Indent == null) ? threadNumber : data.Indent
                };

                threads[threadNumber].Start(tempData);
            }

            foreach (var thread in threads)
            {
                thread.Join();
            }
        }

        public static decimal[] CreateAndFillArray(int arrayLenght)
        {
            var randomArray = new decimal[arrayLenght];
            var methData = new Data() { Array = randomArray };

            Execute((tempData) => Helpers.FillArray((Data)tempData), methData);

            return randomArray;
        }

        public static decimal[] CreateAndCopyArray(decimal[] basicArray, int startIndex, int endIndex)
        {
            var temporaryCopiedArray = new decimal[endIndex - startIndex + 1];
            var methData = new Data() { Array = temporaryCopiedArray, Indent = startIndex, IntermediateArray = basicArray };

            Execute((tempData) => Helpers.CopyArray((Data)tempData), methData);

            return temporaryCopiedArray;
        }

        public static decimal GetArrayMin(decimal[] array)
        {
            var metdData = new Data() { Array = array, IntermediateArray = new decimal[proccessors] };

            Execute((tempData) => Helpers.GetMinimum((Data)tempData), metdData);

            return metdData.IntermediateArray.Min();
        }

        public static decimal GetArrayAverage(decimal[] array)
        {
            var methData = new Data() { Array = array, IntermediateArray = new decimal[proccessors] };

            Execute((tempData) => Helpers.GetAverage((Data)tempData), methData);

            return methData.IntermediateArray.Average();
        }
    }
}

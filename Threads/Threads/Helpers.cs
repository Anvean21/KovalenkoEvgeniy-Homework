using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Threads
{
    public static class Helpers
    {
        static readonly Mutex mutex = new Mutex();
        static decimal rnd = 0;
        private static readonly Random random = new Random();

        public static void FillArray(Data methData)
        {
            for (int i = methData.Start.Value; i < methData.End.Value; i++)
            {
                mutex.WaitOne();
                rnd = random.Next(100);
                mutex.ReleaseMutex();

                methData.Array[i] = rnd;
            }
        }

        public static void CopyArray(Data methData)
        {
            for (int i = methData.Start.Value; i < methData.End.Value; i++)
            {
                methData.Array[i] = methData.IntermediateArray[i + methData.Indent.Value];
            }
        }

        public static void GetMinimum(Data methData)
        {
            decimal min = methData.Array.First();
            for (int i = methData.Start.Value + 1; i < methData.End.Value; i++)
            {
                if (methData.Array[i] < min)
                {
                    min = methData.Array[i];
                }
            }
            methData.IntermediateArray[methData.Indent.Value] = min;
        }

        public static void GetAverage(Data methData)
        {
            for (int i = methData.Start.Value + 1; i < methData.End.Value; i++)
            {
                methData.IntermediateArray[methData.Indent.Value] += methData.Array[i];
            }
            methData.IntermediateArray[methData.Indent.Value] /= methData.End.Value - methData.Start.Value + 1;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqHomework
{
    public static class LinqMethods
    {
        public static void From1To50()
        {
            Console.WriteLine("From 1 to 50");
            Console.WriteLine(String.Join(", ", Enumerable.Range(10,41)));
            Console.WriteLine("\n____________________________________________________________");

        }
        public static void ThreeDivided()
        {
            Console.WriteLine("divided on 3");
            Console.WriteLine(String.Join(", ", Enumerable.Range(10, 40).Where(x => x % 3 == 0)));
            Console.WriteLine("\n____________________________________________________________");
        }
        public static void LinqRepeat()
        {
            Console.WriteLine("10 Linq");
            Console.WriteLine(String.Join(", ", Enumerable.Repeat("Linq", 10)));
            Console.WriteLine("\n____________________________________________________________");
        }
        public static void WordsContains()
        {
            Console.WriteLine("Words whitch contains 'a' ");

            string[] stringArray = { "aaa", "abb", "ccc", "dap" };
            Console.WriteLine(String.Join(", ", stringArray.Where(x => x.Contains('a'))));
            Console.WriteLine("\n____________________________________________________________");
        }
        public static void LetterCount()
        {
            Console.WriteLine("Count of 'a' in words ");

            string[] stringArray = { "aaa", "abb", "ccc", "dap" };
            foreach (var item in stringArray)
            {
                Console.WriteLine(item + " - " + item.Count(x => x == 'a'));

            }
            Console.WriteLine("\n____________________________________________________________");

        }
        public static void IsInString()
        {
            Console.WriteLine("abb in string");
            string[] stringArray = { "aaa", "xabbx", "abb", "ccc", "dap" };
            foreach (var item in stringArray)
            {
                Console.WriteLine(item + " - " + item.Contains("abb"));
            }
            Console.WriteLine("\n____________________________________________________________");
        }
        public static void MaxLenghtString()
        {
            string[] stringArray = { "aaa", "xabbx", "abb", "ccc", "dap" };
            Console.WriteLine("Max lenght - "+stringArray.OrderBy(x => x.Length).Last());
            Console.WriteLine("\n____________________________________________________________");
        }
        public static void AverageLenghtString()
        {
            string[] stringArray = { "aaa", "xabbx", "abb", "ccc", "dap" };
            Console.WriteLine("Average lenght - " + stringArray.Average(x => x.Length));
            Console.WriteLine("\n____________________________________________________________");
        }
        public static void MinLenght()
        {
            Console.WriteLine("Reverse word");
            string[] stringArray = { "aaa", "xabbx", "abb", "ccc", "dap","zh" };
            Console.WriteLine(stringArray.OrderBy(x => x.Length).FirstOrDefault().Reverse().ToArray());
            Console.WriteLine("\n____________________________________________________________");

        }
        public static void StartwithA()
        {
            Console.WriteLine("Start with aa and all b");
            string[] stringArray = { "aaa", "xabbx", "aabb", "baaa", "abb", "ccc", "dap" };
            var firstWord = stringArray.FirstOrDefault(x => x.StartsWith("aa")).ToCharArray().Skip(2).All(x => x == 'b');

            Console.WriteLine(firstWord);
            Console.WriteLine("\n____________________________________________________________");
        }
        public static void LastWord()
        {
            string[] stringArray = { "aaa", "xabbx", "aabb", "baaa", "abb", "ccc", "dap" };
            var lastWord = stringArray.Skip(2).Where(x => x.EndsWith("bb")).LastOrDefault();
            Console.WriteLine(lastWord);
        }
    }
}

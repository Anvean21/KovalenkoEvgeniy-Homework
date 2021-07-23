using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TDDTask
{
    public class StringCalculator
    {
        private event Action<string, int> AddOccured;

        private int Count { get; set; }

        public StringCalculator()
        {
            AddOccured += (str, integer) => { Console.WriteLine($"Теперь тут что-то делается :)\n{str} - {integer}"); };
        }

        public int GetCalledCount()
        {
            return Count;
        }

        public int Add(string numbers)
        {
            Count++;
            var customSeparator = "//";
            var lineSplit = "\n";
            string[] separator = { ",", "\n" };
            string[] bracketsDelimeters = { "[", "]" };

            var result = numbers.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            int sum = 0;

            if (numbers.StartsWith(customSeparator))
            {
                var cuttedString = numbers[2..];
                var delimetr = cuttedString.Split(lineSplit).First();
                var customDelimeters = delimetr.Split(bracketsDelimeters, StringSplitOptions.RemoveEmptyEntries);
                result = cuttedString.Split(lineSplit).Skip(1).First().Split(customDelimeters, StringSplitOptions.RemoveEmptyEntries);
            }

            if (string.IsNullOrEmpty(numbers))
            {
                AddOccured.Invoke(numbers, sum);
                return sum;
            }

            if (result.Where(x => x.StartsWith('-')).Any())
            {
                AddOccured.Invoke(numbers, sum);
                throw new Exception($"negatives not allowed {string.Join(' ', result.Where(x => x.StartsWith('-')))}");
            }

            foreach (var number in result)
            {
                int.TryParse(number, out int parsedNum);

                if (parsedNum > 1000)
                {
                    continue;
                }

                sum += parsedNum;
            }

            AddOccured.Invoke(numbers, sum);

            return sum;
        }
    }
}

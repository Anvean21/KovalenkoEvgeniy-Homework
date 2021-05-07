using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BullsAndCows
{
  public static class Game
    {
        //Функция создает список всех возможных ответовs
        public static List<string> GetAllAnswers()
        {
            var list = new List<string>();
            for (int i = 1000; i < 10000; i++)
            {
                StringBuilder sb = new StringBuilder();

                if (i.ToString().Length == 3)
                {
                    list.Add(sb.Append("0" + i.ToString()).ToString());
                }
                else if (i.ToString().Length == 4)
                {
                    list.Add(sb.Append(i.ToString()).ToString());
                }
            }
            var answer = new List<String>();
            foreach (var j in list)
            {
                if (new string(j.Distinct().ToArray()).Length == 4)
                {
                    answer.Add(j);
                }
            }
            return answer;
        }
        //Выбирает один ответ из списка возможных
        public static int GetOneAnswer(List<string> answer)
        {
            var index = new Random().Next(answer.Count);
            return Int32.Parse(answer[index]);
        }
        //Запрашиваем у пользователя 4 неповторяющиеся цифры
        public static int InputNumber()
        {
            while (true)
            {
                Console.WriteLine("Введите 4 неповторяющихся цифры");
                int num = Int32.Parse((Console.ReadLine().Trim()));

                if (num.ToString().Length != 4)
                {
                    InputNumber();
                }
                if (new string(num.ToString().Distinct().ToArray()).Length == 4)
                {
                    return num;
                }
            }
        }
        //Сравнивает два числа и сообщает о колитчестве быков и коров
        public static int[] Check(int number, int trueNumber)
        {
            int bulls = 0;
            int cows = 0;
            char[] inputString = number.ToString().ToCharArray();
            char[] trueString = trueNumber.ToString().ToCharArray();
            for (int i = 0; i < inputString.Length; i++)
            {
                if (inputString[i] == trueString[i])
                {
                    bulls += 1;
                    continue;
                }
                for (int j = 0; j < trueString.Length; j++)
                {
                    if (inputString[i] == trueString[j])
                    {
                        cows += 1;
                    }
                }
            }
            return new int[] { bulls, cows };
        }
        //Компьютер удаляет неподходящие ответы из списка возможных
        public static void DeleteAnswers()
        {

        }
    }
}

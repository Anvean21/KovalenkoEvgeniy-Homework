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
            var answer = new List<string>();
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
        public static string GetOneAnswer(List<string> answer)
        {
            var index = new Random().Next(answer.Count);
            return answer[index];
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
        public static int[] Check(string trueNumber, string currentAnswer)
        {
            int bulls = 0;
            int cows = 0;
            char[] inputString = currentAnswer.ToCharArray();
            char[] trueString = trueNumber.ToCharArray();
            for (int i = 0; i < inputString.Length; i++)
            {
                if (inputString[i] == trueString[i])
                {
                    bulls ++;
                }
                else
                {
                    for (int j = 0; j < trueString.Length; j++)
                    {
                        if (inputString[i] == trueString[j])
                        {
                            cows++;
                        }
                    }
                }
                
            }
            return new int[] { bulls, cows };
        }
        //Компьютер удаляет неподходящие ответы из списка возможных
        public static List<string> DeleteAnswers(List<string> answer, string currentAnswer, int bulls, int cows)
        {
            var generalAnswers = answer.ToList();
            foreach (var item in answer)
            {
                int[] cowsAndBulls = Check(item, currentAnswer);
                if (cowsAndBulls[0] != bulls || cowsAndBulls[1] != cows)
                {
                    generalAnswers.Remove(item);
                }
            }
            return generalAnswers;
        }

        public static void ComputerVersusPlayer()
        {
            var answers = GetAllAnswers();
            while (true)
            {
                string currentAnswer = GetOneAnswer(answers);
                Console.WriteLine($"Ваше число - {currentAnswer} ?");

                Console.WriteLine("Сколько быков?");
                int bulls = int.Parse(Console.ReadLine());
                Console.WriteLine("Сколько коров?");
                int cows = int.Parse(Console.ReadLine());

                if (answers.Count == 1)
                {
                    Console.WriteLine($"Ваше число - {answers[0]}");
                    return;
                }
                else if (bulls == 4)
                {
                    Console.WriteLine("Победил Компьютер!");
                    Console.WriteLine($"Вы загадал число {currentAnswer} !");
                    return;
                }
                else
                {
                    answers = DeleteAnswers(answers, currentAnswer, bulls, cows);
                }
            }
        }
    }
}

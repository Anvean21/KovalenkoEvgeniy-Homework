using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BullsAndCows
{
    public static class Game
    {
        static List<string> generalAnswers = GetAllAnswers();

        public static void ComputerVersusPlayer()
        {
            string currentAnswer = GetOneAnswer(generalAnswers);
            List<string> currentPossibleAnswers = generalAnswers;

            Console.WriteLine($"Может ваше число {currentAnswer} ?");

            Console.Write("Cколько быков? ");
            int bulls = Convert.ToInt32(Console.ReadLine());
            Console.Write("Сколько коров? ");
            int cows = Convert.ToInt32(Console.ReadLine());

            if (bulls < 0 || bulls > 4 || cows < 0 || cows > 4)
            {
                Console.WriteLine("Число быков или коров должно быть не меньше 0 и не больше 4х ");
                return;
            }
            else if (bulls == 4)
            {
                Console.WriteLine($"Ваше число - {currentAnswer}!");
                return;
            }

            generalAnswers = AddAnswer(currentAnswer, bulls, cows, currentPossibleAnswers);

            if (generalAnswers.Count == 1)
            {
                Console.WriteLine($"Ваше число - {generalAnswers[0]}!");
            }
            else
            {
                ComputerVersusPlayer();
            }
        }

        private static List<string> AddAnswer(string currentAnswer, int bulls, int cows, List<string> currentPossibleAnswers)
        {
            List<string> newAnswers = new List<string>();
            for (int i = 0; i < currentPossibleAnswers.Count; i++)
            {
                var bullAndCows = CheckBullsAndCows(currentAnswer, currentPossibleAnswers[i]);

                if (bulls == bullAndCows[0] && cows == bullAndCows[1])
                {
                    newAnswers.Add(currentPossibleAnswers[i]);
                }
            }
            return newAnswers;
        }

        private static int[] CheckBullsAndCows(string currentAnswer, string answerFromPossibleMassive)
        {
            char[] current = currentAnswer.ToCharArray();
            char[] possible = answerFromPossibleMassive.ToCharArray();
            int bulls = 0;
            int cows = 0;

            for (int i = 0; i < current.Length; i++)
            {
                if (current[i] == possible[i])
                {
                    bulls++;
                }
                else
                {
                    for (int j = 0; j < possible.Length; j++)
                    {
                        if (current[i] == possible[j])
                        {
                            cows++;
                        }
                    }
                }
            }

            return new[] {bulls,cows };
        }
        static List<string> GetAllAnswers()
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

        //get one answer from possible list
        static string GetOneAnswer(List<string> answers)
        {
            var index = new Random().Next(answers.Count);
            return answers[index];
        }
    }
}


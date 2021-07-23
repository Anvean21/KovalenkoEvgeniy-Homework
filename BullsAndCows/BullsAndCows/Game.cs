using System;
using System.Collections.Generic;
using System.Text;

namespace BullsAndCows
{
    public class Game
    {
        static Random random = new Random();

        public static void Start()
        {
            List<string> Combinations = GenerateCombinations();
            int round = 1;
            Console.Write("\t\tBulls and cows");
            while (true)
            {
                Shuffle(Combinations);
                Console.WriteLine($"\nRound {round}");
                Console.WriteLine($"Number: {Combinations[0]} | Options left: {Combinations.Count}");
                Console.Write("Bulls: ");
                int bulls = int.Parse(Console.ReadLine());
                Console.Write("Cows: ");
                int cows = int.Parse(Console.ReadLine());
                cows += bulls;
                if (bulls == 4)
                {
                    Console.WriteLine("Number is " + Combinations[0]);
                    break;
                }

                round++;
                DeleteElements(Combinations, bulls, cows);
            }

            Console.ReadKey();
        }

        public static List<string> GenerateCombinations()
        {
            List<string> generatedList = new List<string>();

            for (int i = 0; i <= 9999; i++)
            {
                int d1 = i / 1000;
                int d2 = (i / 100) % 10;
                int d3 = (i / 10) % 10;
                int d4 = i % 10;
                if (d4 == 0 && d3 == 0 && d2 == 0 && d1 == 0)
                {
                    generatedList.Add("0000");
                    continue;
                }

                if (d3 == 0 && d2 == 0 && d1 == 0)
                {
                    generatedList.Add("000" + string.Join("", i));
                    continue;
                }

                if (d2 == 0 && d1 == 0)
                {
                    generatedList.Add("00" + string.Join("", i));
                    continue;
                }

                if (d1 == 0)
                {
                    generatedList.Add('0' + string.Join("", i));
                }
                else
                {
                    generatedList.Add(string.Join("", i));
                }
            }

            return generatedList;
        }

        public static void Shuffle(List<string> list)
        {
            int counter = list.Count;
            while (counter > 1)
            {
                counter--;
                int k = random.Next(counter + 1);
                string value = list[k];
                list[k] = list[counter];
                list[counter] = value;
            }
        }

        static bool Checker(string s, string GuessingStr, int bulls, int cows)
        {
            string temp1 = "", temp2 = "";
            int bullsCounter = 0, cowsCounter = 0;
            for (int i = 0; i < 4; i++)
            {
                if (s[i] == GuessingStr[i])
                {
                    temp1 += '-';
                    temp2 += '*';
                    bullsCounter++;
                }
                else
                {
                    temp1 += s[i];
                    temp2 += GuessingStr[i];
                }
            }

            for (int i = 0; i < 4; i++)
            {
                if (temp1.IndexOf(temp2[i]) > -1)
                {
                    cowsCounter++;
                }
            }

            return (cowsCounter == cows) && (bullsCounter == bulls);
        }

        public static void DeleteElements(List<string> combinations, int bulls, int cows)
        {
            string result = combinations[0];
            for (int i = 0; i < combinations.Count; i++)
            {
                if (!Checker(combinations[i], result, bulls, cows))
                {
                    combinations.Remove(combinations[i]);
                    i--;
                }
            }
        }
    }
}

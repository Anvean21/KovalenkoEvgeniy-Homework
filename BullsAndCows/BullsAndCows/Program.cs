using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BullsAndCows
{
    class Program
    {
        static void Main(string[] args)
        {

            var answers = Game.GetAllAnswers();
            var player = Game.InputNumber();
            var enemy = Game.GetOneAnswer(answers);
            Game.Check(player, enemy).ToString();
        }
    }
}

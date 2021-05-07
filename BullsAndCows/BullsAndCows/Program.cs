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
            Console.WriteLine("Быки и коровы");
            Console.WriteLine("Желаете загадывать число, или отгадывать? \n1 - загадывать\n2 - отгадывать");
            switch (Console.ReadLine())
            {
                case "1":
                    Game.ComputerVersusPlayer();
                    break;
                case "2":
                    Game.PlayerVersusComputer();
                    break;
                default:
                    Game.ComputerVersusPlayer();
                    break;
            }
        }
    }
}

using FileManager.Readers;
using System;

namespace FileManager
{
    class Program
    {
        static void Main(string[] args)
        {
            var pathView = new PathViewer();

            while (true)
            {
                pathView.Display();
                pathView.Run(Console.ReadLine());
            }
        }
    }
}

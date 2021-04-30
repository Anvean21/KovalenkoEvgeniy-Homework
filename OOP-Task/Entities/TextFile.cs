using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Task
{
    public class TextFile : AbstractFile
    {
        public string FileContent { get; set; }
        public override void Print(AbstractFile file)
        {
            Console.WriteLine("Text file:");
            base.Print(file);
            Console.Write($"\t\tContent: {FileContent}\n");
        }
    }
}

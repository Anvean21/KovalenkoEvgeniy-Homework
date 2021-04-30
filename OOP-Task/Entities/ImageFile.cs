using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Task
{
    public class ImageFile : AbstractFile
    {
        static ImageFile()
        {
            Console.WriteLine("Images :");
        }
        public string Resolution { get; set; }
        public override void Print(AbstractFile file)
        {
            base.Print(file);
            Console.Write($"\t\tResolution: {Resolution}\n");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Task
{
    public class ImageFile : AbstractFile
    {
        public string Resolution { get; set; }
        public override void Print(AbstractFile file)
        {
            Console.WriteLine("Image file:");
            base.Print(file);
            Console.Write($"\t\tResolution: {Resolution}\n");
        }
    }
}

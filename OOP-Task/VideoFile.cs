using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Task
{
    public class VideoFile:AbstractFile
    { 
        public string Resolution { get; set; }
        public string Length { get; set; }
        public override void Print(AbstractFile file)
        {
            Console.WriteLine("Video file:");
            base.Print(file);
            Console.Write($"\t\tResolution: {Resolution}\n\t\tLength: {Length}\n");
        }
    }
}

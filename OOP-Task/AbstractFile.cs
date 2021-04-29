using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Task
{
    public abstract class AbstractFile
    {
        public string FileName { get; set; }
        public string FileExtension { get; set; }
        public string FileSize { get; set; }

        public virtual void Print(AbstractFile file)
        {
            Console.WriteLine($"\n\t{file.FileName}\n\t\tExtension: {file.FileExtension}\n\t\t Size: {file.FileSize}");
        }
    }
}

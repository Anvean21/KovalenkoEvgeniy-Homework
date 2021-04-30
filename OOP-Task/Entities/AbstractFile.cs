using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

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
        public static string SearchFileName(string name)
        {
            string patternName = @":.*\(";
            string extra = @":|\(";
            string result = Regex.Match(name, patternName).Value;
            return new Regex(extra).Replace(result, String.Empty);
        }
        public static string SearchFileSize(string size)
        {
            string patternSize = @"\(\w*\)";
            string extra = @"\(|\)";
            string result = Regex.Match(size, patternSize).Value;
            return new Regex(extra).Replace(result, String.Empty);
        }
        public static string SearchFileExtension(string extension)
        {
            string[] str = extension.Split('.', '(');
            return "." + str[1];
            
        }
    }
}

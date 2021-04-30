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
        public static string RegexName(string name)
        {
            string patternName = @":.*\(";
            string extra = @":|\(";
            var value = Regex.Match(name, patternName);
            string result = value.Value;
            result = new Regex(extra).Replace(result, "");
            return result;
        }
    }
}

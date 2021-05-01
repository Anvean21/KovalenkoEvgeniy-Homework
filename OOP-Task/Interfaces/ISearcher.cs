using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace OOP_Task.Interfaces
{
  public interface ISearcher
    {
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

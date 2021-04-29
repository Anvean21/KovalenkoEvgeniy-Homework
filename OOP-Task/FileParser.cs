using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Task
{
    public class FileParser
    {
        public IParser<AbstractFile> Parser { get; set; }
        public FileParser(IParser<AbstractFile> parser)
        {
            Parser = parser;
        }
        public void ExecuteParser(string inputFile)
        {
            Parser.Parse(inputFile);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Task
{
    public class TextParser : IParser<AbstractFile>
    {
        public AbstractFile Parse(string inputString)
        {
            TextFile txt = new TextFile();
            string[] str = inputString.Split("\r");
            foreach (var item in str)
            {
                if (item.Contains(".txt"))
                {
                    string[] pars = item.Split(new[] { ':', '.', '(', ')', ';' }, StringSplitOptions.RemoveEmptyEntries);

                    txt.FileName = pars[1];
                    txt.FileExtension = pars[2];
                    txt.FileSize = pars[3];
                    txt.FileContent = pars[4];

                    txt.Print(txt);
                }
            }
            return txt;
        }
    }
}

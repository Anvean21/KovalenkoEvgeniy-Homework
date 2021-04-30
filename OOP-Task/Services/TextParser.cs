using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Task
{
    public class TextParser : IParser<AbstractFile>
    {
        
        public AbstractFile Parse(string[] inputString)
        {
            TextFile txt = new TextFile();

            foreach (var item in inputString)
            {
                if (item.Contains(".txt"))
                {

                    txt.FileName = AbstractFile.SearchFileName(item);
                    txt.FileExtension = AbstractFile.SearchFileExtension(item);
                    txt.FileSize = AbstractFile.SearchFileSize(item);
                    txt.FileContent = SearchFileContent(item);

                    txt.Print(txt);
                }
            }
            return txt;
        }

        public static string SearchFileContent(string content)
        {
            string[] str = content.Split(';');
            return str[1];
        }
    }
}

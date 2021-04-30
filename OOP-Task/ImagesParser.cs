using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Task
{
    public class ImagesParser : IParser<AbstractFile>
    {
        public AbstractFile Parse(string[] inputString)
        {
            ImageFile img = new ImageFile();
            foreach (var item in inputString)
            {
                if (item.Contains(".bmp"))
                {
                    string[] pars = item.Split(new[] { '.', '(', ')', ';' }, StringSplitOptions.RemoveEmptyEntries);

                    img.FileName = AbstractFile.RegexName(item);
                    img.FileExtension = pars[1];
                    img.FileSize = pars[2];
                    img.Resolution = pars[3];

                    img.Print(img);
                }
            }
            return img;
        }
    }
}

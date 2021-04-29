using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Task
{
    public class ImagesParser : IParser<AbstractFile>
    {
        public AbstractFile Parse(string inputString)
        {
            ImageFile img = new ImageFile();
            string[] str = inputString.Split("\r");
            foreach (var item in str)
            {
                if (item.Contains(".bmp"))
                {
                    string[] pars = item.Split(new[] { ':', '.', '(', ')', ';' }, StringSplitOptions.RemoveEmptyEntries);

                    img.FileName = pars[1];
                    img.FileExtension = pars[2];
                    img.FileSize = pars[3];
                    img.Resolution = pars[4];

                    img.Print(img);
                }
            }
            return img;
        }
    }
}

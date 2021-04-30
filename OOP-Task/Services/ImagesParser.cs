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
                    img.FileName = AbstractFile.SearchFileName(item);
                    img.FileExtension = AbstractFile.SearchFileExtension(item);
                    img.FileSize = AbstractFile.SearchFileSize(item);
                    img.Resolution = ImageFile.SearchFileResolution(item);

                    img.Print(img);
                }
            }
            return img;
        }
    }
}

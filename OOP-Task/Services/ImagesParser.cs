using OOP_Task.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Task
{
    public class ImagesParser : IParser<AbstractFile>, ISearcher
    {
        public AbstractFile Parse(string[] inputString)
        {
            ImageFile img = new ImageFile();
            foreach (var item in inputString)
            {
                if (item.Contains(".bmp"))
                {
                    img.FileName = ISearcher.SearchFileName(item);
                    img.FileExtension = ISearcher.SearchFileExtension(item);
                    img.FileSize = ISearcher.SearchFileSize(item);
                    img.Resolution = SearchFileResolution(item);

                    img.Print(img);
                }
            }
            return img;
        }
        public static string SearchFileResolution(string resolution)
        {
            string[] str = resolution.Split(';');
            return str[1];
        }
    }
}

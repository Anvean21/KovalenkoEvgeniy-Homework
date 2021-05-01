using OOP_Task.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Task
{
    public class VideosParser :  IParser<AbstractFile>, ISearcher
    {
        public AbstractFile Parse(string[] inputString)
        {
            VideoFile video = new VideoFile();
            foreach (var item in inputString)
            {
                if (item.Contains(".mkv"))
                {
                    video.FileName = ISearcher.SearchFileName(item);
                    video.FileExtension = ISearcher.SearchFileExtension(item);
                    video.FileSize = ISearcher.SearchFileSize(item);
                    video.Resolution = SearchFileResolution(item);
                    video.Length = SearchFileLenght(item);

                    video.Print(video);
                }
            }
            return video;
        }
        public static string SearchFileResolution(string resolution)
        {
            string[] str = resolution.Split(';');
            return str[1];
        }
        public static string SearchFileLenght(string resolution)
        {
            string[] str = resolution.Split(';');
            return str[2];
        }
    }
}

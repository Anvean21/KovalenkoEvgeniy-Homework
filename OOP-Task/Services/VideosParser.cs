using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Task
{
    public class VideosParser :  IParser<AbstractFile>
    {
        public AbstractFile Parse(string[] inputString)
        {
            VideoFile video = new VideoFile();
            foreach (var item in inputString)
            {
                if (item.Contains(".mkv"))
                {
                    video.FileName = AbstractFile.SearchFileName(item);
                    video.FileExtension = AbstractFile.SearchFileExtension(item);
                    video.FileSize = AbstractFile.SearchFileSize(item);
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

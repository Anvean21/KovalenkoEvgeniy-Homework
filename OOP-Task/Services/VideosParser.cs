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
                    video.Resolution = VideoFile.SearchFileResolution(item);
                    video.Length = VideoFile.SearchFileLenght(item);

                    video.Print(video);
                }
            }
            return video;
        }
    }
}

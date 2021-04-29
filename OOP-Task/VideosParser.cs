using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Task
{
    public class VideosParser :  IParser<AbstractFile>
    {
        public AbstractFile Parse(string inputString)
        {
            VideoFile video = new VideoFile();
            string[] str = inputString.Split("\r");
            foreach (var item in str)
            {
                if (item.Contains(".mkv"))
                {
                    string[] pars = item.Split(new[] {'.', ':', '(', ')', ';', ';' }, StringSplitOptions.RemoveEmptyEntries);

                    video.FileName = pars[1] + pars[2];
                    video.FileExtension = pars[3];
                    video.FileSize = pars[4];
                    video.Resolution = pars[5];
                    video.Length = pars[6];

                    video.Print(video);
                }
            }
            return video;
        }
    }
}

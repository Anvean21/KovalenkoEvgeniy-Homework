using System;
using System.Collections.Generic;
using System.Text;

namespace EFPractice.Core.Entities.Files
{
    public class AudioFile : File
    {
        public int BitRate { get; set; }
        public int SampleRate { get; set; }
        public int ChannelCount { get; set; }
        public TimeSpan Duration { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace EFPractice.Core.Entities.Files
{
    public class VideoFile : File
    {
        public int Height { get; set; }
        public int Weight { get; set; }
        public TimeSpan Duration { get; set; }
    }
}

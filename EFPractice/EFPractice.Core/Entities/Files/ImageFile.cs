using System;
using System.Collections.Generic;
using System.Text;

namespace EFPractice.Core.Entities.Files
{
    public class ImageFile : File
    {
        public int Height { get; set; }
        public int Weight { get; set; }
    }
}

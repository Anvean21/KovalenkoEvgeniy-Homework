using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileManager
{
    public class AnyFileReader : IFileReader
    {
        public int Count => 2048;

        public string FileExtension => "";

        public string GetFile(string path)
        {
            var buffer = new byte[Count];
            var readCount = 0;
            using (var stream = File.OpenRead(path))
            {
                readCount = stream.Read(buffer, 0, Count);
            }
            return BitConverter.ToString(buffer, 0, readCount).Replace('-', ' ');

        }
    }
}

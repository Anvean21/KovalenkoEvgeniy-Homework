using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileManager
{
    public class TxtReader : IFileReader
    {
        public int Count => 1024;

        public string FileExtension => ".txt";

        public string GetFile(string path)
        {
            var result = new char[Count];
            using (var stream = File.OpenText(path))
            {
                stream.Read(result, 0, Count);
            }
            return new string(result);
        }
    }
}

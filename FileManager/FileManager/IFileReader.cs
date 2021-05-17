using System;
using System.Collections.Generic;
using System.Text;

namespace FileManager
{
    public interface IFileReader
    {
        public string GetFile(string path);
        public int Count { get;}
        public string FileExtension { get;}
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace FileManager.Readers
{
    public class PathViewer
    {
        private string currentPath;
        public IEnumerable<Type> fileReaders;
        private static readonly string exit = "exit";
        private static readonly string back = "cd..";
        private static readonly string splitSymbol = @"\";

        public PathViewer(string basePath = @"c:\")
        {
            if (!Path.IsPathRooted(basePath))
            {
                throw new ArgumentException(nameof(basePath));
            }
            currentPath = basePath;

            fileReaders = Assembly.GetExecutingAssembly().GetTypes().Where(type => type.GetInterfaces().Contains(typeof(IFileReader)));
        }

        public void Display()
        {
            TryDisplay();

            var directories = Directory.EnumerateDirectories(currentPath)
                .Select(d => new DirectoryInfo(d)).OrderBy(o => o.Name).Cast<FileSystemInfo>()
                .Concat(Directory.EnumerateFiles(currentPath).Select(f => new FileInfo(f)).OrderBy(o => o.Name));

            Console.Clear();
            Console.WriteLine(currentPath);

            foreach (var d in directories)
            {
                Console.WriteLine($"\t{d.Name}");
            }
        }

        public void TryDisplay()
        {
            if (!File.Exists(currentPath))
            {
                return;
            }
            var extension = Path.GetExtension(currentPath).ToLower();

            var fileReader = fileReaders.FirstOrDefault(type => type.CreateInstance<IFileReader>().FileExtension.Contains(extension)) ?? typeof(AnyFileReader);
            string resultString = fileReader.CreateInstance<IFileReader>().GetFile(currentPath);

            Console.Clear();
            Console.WriteLine(resultString);
            Console.ReadLine();
            Run(Path.GetDirectoryName(currentPath));
        }

        public void Run(string directoryName)
        {
            if (directoryName == exit)
            {
                Environment.Exit(0);
            }
            else if (directoryName == back)
            {
                var previousPath = currentPath.Split(splitSymbol).LastOrDefault();
                var newPath = Path.GetFullPath(currentPath.Replace(previousPath, string.Empty));
                if (Directory.Exists(newPath) || File.Exists(newPath))
                {
                    currentPath = newPath;
                }
            }
            else
            {
                var newPath = Path.Combine(currentPath, directoryName);
                newPath = Path.GetFullPath(newPath);
                if (Directory.Exists(newPath) || File.Exists(newPath))
                {
                    currentPath = newPath;
                }
            }
        }
    }
}

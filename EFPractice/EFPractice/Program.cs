using EFPractice.Core.Entities;
using EFPractice.Core.Services;
using EFPractice.DAL;
using System;
using System.Linq;

namespace EFPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = Startup.ConfigureService();
            var serviceFile = (IFileService)config.GetService(typeof(IFileService));
            var directoryService = (IDirectoryService)config.GetService(typeof(IDirectoryService));

            var userId = 1;
            var directoryId = 3;
            var pageNumber = 1;
            var pageSize = 10;

            var firstTaskResult = serviceFile.GetReadFiles(userId, directoryId, pageNumber, pageSize);
            Console.WriteLine(string.Join(", ", firstTaskResult.Result.Items.Where(x => x.FilePermissions.Any()).Select(x => x.Title + "." + x.Extention)));
            Console.WriteLine("___________________________________________________");

            directoryId = 1;
            userId = 3;

            var secondTaskResult = directoryService.GetNestedDirectories(userId, directoryId, pageNumber, pageSize);
            foreach (var directory in secondTaskResult.Result.OfType<Directory>())
            {
                Console.WriteLine(directory.Title);

                Console.WriteLine(string.Join(", ", secondTaskResult.Result.OfType<File>().Select(x => x.Title + "." + x.Extention)));
                var parentDirectory = secondTaskResult.Result.OfType<Directory>().FirstOrDefault(x => x.Id == directory.ParentDirectoryId);
                //Console.WriteLine(parentDirectory.Title);
            }
            Console.WriteLine("___________________________________________________");

            userId = 3;
            directoryId = 3;
            var thirdTaskResult = directoryService.GetDirectoryAndFiles(userId, directoryId, pageNumber, pageSize);
            Console.WriteLine(string.Join("\n", thirdTaskResult));

            Console.WriteLine("___________________________________________________");

            var fourthTaskResult = serviceFile.GetFilesCount(userId, directoryId);
            Console.WriteLine($"All files in dir.: {fourthTaskResult.First()}, Files which user can read: {fourthTaskResult.Last()}");

            Console.WriteLine("___________________________________________________");
            var fifthTaskResult = serviceFile.GetGropedFiles(directoryId);
            foreach (var item in fifthTaskResult)
            {
                Console.WriteLine(item);
            }

        }
    }
}

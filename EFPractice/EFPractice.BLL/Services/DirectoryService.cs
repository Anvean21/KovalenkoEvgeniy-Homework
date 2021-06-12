using EFPractice.Core.Entities;
using EFPractice.Core.Interfaces;
using EFPractice.Core.Models;
using EFPractice.Core.Services;
using EFPractice.Core.Spetification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EFPractice.BLL.Services
{
    public class DirectoryService : IDirectoryService
    {
        private readonly IRepository<Directory> directoryRepository;
        private readonly IRepository<File> fileRepository;

        public DirectoryService(IRepository<Directory> directoryRepository, IRepository<File> fileRepository)
        {
            this.directoryRepository = directoryRepository;
            this.fileRepository = fileRepository;
        }

        public Task<List<BaseEntity>> GetNestedDirectories(int userId, int directoryId, int pageNumber, int pageSize, CancellationToken cancellationToken = default)
        {
            var directoryIncludes = new List<Expression<Func<Directory, object>>>
            {
                y => y.DirectoryPermissions.Where(x => x.UserId == userId && x.CanRead)
            };

            var fileIncludes = new List<Expression<Func<File, object>>>
            {
                y => y.FilePermissions.Where(x => x.UserId == userId && x.CanRead)
            };

            var result = new List<BaseEntity>();

            var specDir = new Specification<Directory>(x => x.ParentDirectoryId == directoryId, directoryIncludes);
            var specFile = new Specification<File>(x => x.DirectoryId == directoryId, fileIncludes);

            var directories = this.directoryRepository.GetAsync(specDir,
                pageNumber, pageSize, cancellationToken).Result.Items.Where(x => x.DirectoryPermissions.Any(y => y.UserId == userId)).ToList();

            var files = fileRepository.GetAsync(specFile,
                pageNumber, pageSize, cancellationToken).Result.Items.Where(x => x.FilePermissions.Any(y => y.UserId == userId)).ToList();

            result.AddRange(directories);
            result.AddRange(files);
            return Task.FromResult(result);
        }


        public List<string> GetDirectoryAndFiles(int userId, int directoryId, int pageNumber, int pageSize, CancellationToken cancellationToken = default)
        {
            var result = new List<string>();
            var directory = directoryRepository.FindAsync(directoryId).Result;

            var path = directoryRepository.FindAsync(directory.ParentDirectoryId).Result.Title;

            result.AddRange(FilesInDirectory(userId, path, directoryId, pageNumber, pageSize));
            return result;
        }

        private List<string> FilesInDirectory(int userId, string path, int? directoryId, int pageNumber, int pageSize, CancellationToken cancellationToken = default)
        {
            var result = new List<string>();

            var dirInclude = new List<Expression<Func<Directory, object>>>
            {
                y => y.DirectoryPermissions.Where(x => x.UserId == userId && x.CanRead)
            };
            var fileInclude = new List<Expression<Func<File, object>>>
            {
                y => y.FilePermissions.Where(x => x.UserId == userId && x.CanRead)
            };

            var specDir = new Specification<Directory>(x => x.ParentDirectoryId == directoryId, dirInclude);
            var directories = directoryRepository.GetAsync(specDir, pageNumber, pageSize, cancellationToken).Result.Items.ToList();

            var specFile = new Specification<File>(x => x.DirectoryId == directoryId, fileInclude);
            var files = fileRepository.GetAsync(specFile, pageNumber, pageSize, cancellationToken).Result.Items.ToList();

            var directory = directoryRepository.FindAsync(directoryId).Result;

            var curPath = path + directory.Title + @"\";

            directories = directories.Where(x => x.DirectoryPermissions != null && x.DirectoryPermissions.Any(y => y.UserId == userId)).ToList();
            files = files.Where(x => x.FilePermissions != null && x.FilePermissions.Any(y => y.UserId == userId)).ToList();

            foreach (var director in directories)
            {
                result.AddRange(FilesInDirectory(userId, curPath, director.ParentDirectoryId, pageNumber, pageSize));
            }
            foreach (var file in files)
            {
                result.Add(curPath + file.Title + "." + file.Extention);
            }
            return result;
        }

    }
}

using EFPractice.Core.Entities;
using EFPractice.Core.Entities.Files;
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
    public class FileService : IFileService
    {
        private readonly IRepository<File> fileRepository;
        private readonly IRepository<AudioFile> audioFileRepository;
        private readonly IRepository<VideoFile> videoFileRepository;
        private readonly IRepository<TextFile> textFileRepository;
        private readonly IRepository<ImageFile> imageFileRepository;
        public FileService(IRepository<File> fileRepository, IRepository<AudioFile> audioFileRepository, IRepository<VideoFile> videoFileRepository, IRepository<TextFile> textFileRepository, IRepository<ImageFile> imageFileRepository)
        {
            this.fileRepository = fileRepository;
            this.audioFileRepository = audioFileRepository;
            this.videoFileRepository = videoFileRepository;
            this.textFileRepository = textFileRepository;
            this.imageFileRepository = imageFileRepository;
        }
        public Task<PagedList<File>> GetReadFiles(int userId, int directoryId, int pageNumber, int pageSize, CancellationToken cancellationToken = default)
        {
            var includes = new List<Expression<Func<File, object>>>
            {
                y => y.FilePermissions.Where(x => x.CanRead && x.UserId == userId)
            };

            var specFile = new Specification<File>(x => x.DirectoryId == directoryId, includes);
            return fileRepository.GetAsync(specFile, pageNumber, pageSize, cancellationToken);
        }
        public List<int> GetFilesCount(int userId, int directoryId, CancellationToken cancellationToken = default)
        {
            var result = new List<int>();
            var includes = new List<Expression<Func<File, object>>>
            {
                y => y.FilePermissions.Where(x => x.CanRead == true && x.UserId == userId)
            };

            var specFile = new Specification<File>(x => x.DirectoryId == directoryId);
            var specWithInc = new Specification<File>(x => x.DirectoryId == directoryId,includes);

            result.Add(fileRepository.GetAsync(specFile, cancellationToken).Result.Count());
            result.Add(fileRepository.GetAsync(specWithInc, cancellationToken).Result.Count());

            return result;
        }

        public List<string> GetGropedFiles(int directoryId, CancellationToken cancellationToken = default)
        {
            var result = new List<string>();
            var imgSpec = new Specification<ImageFile>(x => x.DirectoryId == directoryId);
            var audSpec = new Specification<AudioFile>(x => x.DirectoryId == directoryId);
            var vidSpec = new Specification<VideoFile>(x => x.DirectoryId == directoryId);
            var txtSpec = new Specification<TextFile>(x => x.DirectoryId == directoryId);

            var files = imageFileRepository.GetAsync(imgSpec, cancellationToken).Result.GroupBy(x => x.Type).Select(x => $" {x.Key}, Count = {x.Count()} ")
                .Union(audioFileRepository.GetAsync(audSpec, cancellationToken).Result.GroupBy(x => x.Type).Select(x => $" {x.Key}, Count = {x.Count()} "))
                .Union(videoFileRepository.GetAsync(vidSpec, cancellationToken).Result.GroupBy(x => x.Type).Select(x => $" {x.Key}, Count = {x.Count()} "))
                .Union(textFileRepository.GetAsync(txtSpec, cancellationToken).Result.GroupBy(x => x.Type).Select(x => $" {x.Key}, Count = {x.Count()} ")).ToList();


            return files;
        }
    }
}

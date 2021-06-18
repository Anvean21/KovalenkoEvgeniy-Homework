using EFPractice.Core.Entities;
using EFPractice.Core.Models;
using EFPractice.Core.Spetification;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EFPractice.Core.Services
{
    public interface IFileService
    {
        public Task<PagedList<File>> GetReadFiles(int userId, int directoryId, int pageNumber, int pageSize, CancellationToken cancellationToken = default);
        public List<int> GetFilesCount(int userId, int directoryId, CancellationToken cancellationToken = default);
        public List<string> GetGropedFiles(int directoryId, CancellationToken cancellationToken = default);

    }
}

using EFPractice.Core.Entities;
using EFPractice.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EFPractice.Core.Services
{
    public interface IDirectoryService
    {
        public Task<List<BaseEntity>> GetNestedDirectories(int userId,int directoryId, int pageNumber, int pageSize, CancellationToken cancellationToken = default);
        public List<string> GetDirectoryAndFiles(int userId, int directoryId, int pageNumber, int pageSize, CancellationToken cancellationToken = default);
    }
}

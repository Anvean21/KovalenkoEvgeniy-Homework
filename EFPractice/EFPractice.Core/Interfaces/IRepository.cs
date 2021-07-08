using EFPractice.Core.Entities;
using EFPractice.Core.Models;
using EFPractice.Core.Spetification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EFPractice.Core.Interfaces
{
    public interface IRepository<TEntity>
        where TEntity : BaseEntity
    {

        Task<TEntity> FindAsync(int? id, CancellationToken cancellationToken = default);

        Task<IEnumerable<TEntity>> GetAsync(Specification<TEntity> specification, CancellationToken cancellationToken = default);

        Task<PagedList<TEntity>> GetAsync(Specification<TEntity> specification, int pageNumber, int pageSize, CancellationToken cancellationToken = default);
    }
}

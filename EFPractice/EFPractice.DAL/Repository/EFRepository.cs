using EFPractice.Core.Entities;
using EFPractice.Core.Interfaces;
using EFPractice.Core.Models;
using EFPractice.Core.Spetification;
using EFPractice.DAL.Extentions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EFPractice.DAL.Repository
{
    public class EFRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly FileContext context;
        protected readonly DbSet<TEntity> entities;

        public EFRepository(FileContext context)
        {
            this.context = context;
            entities = this.context.Set<TEntity>();
        }

        public virtual Task<TEntity> FindAsync(int? id, CancellationToken cancellationToken = default)
        {
            return entities.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAsync(Specification<TEntity> specification, CancellationToken cancellationToken = default)
        {
<<<<<<< HEAD
            var includes = Include(specification);

            return await includes.Where(specification.Expression).ToListAsync(cancellationToken).ConfigureAwait(false);
=======
            var query = entities.Where(x => true);
            if (specification.Include != null)
            {
                foreach (var include in specification.Include)
                {
                    query = query.Include(include);
                }
            }
            return await query.Where(specification.Expression).ToListAsync(cancellationToken).ConfigureAwait(false);
>>>>>>> eb8acc38da2f50c53d5b79eaa87bdd685850ed98
        }

        public virtual Task<PagedList<TEntity>> GetAsync(Specification<TEntity> specification, int pageNumber, int pageSize, CancellationToken cancellationToken = default)
        {
<<<<<<< HEAD
            var includes = Include(specification);
            return includes.Where(specification.Expression).ToPagedListAsync(pageNumber, pageSize, cancellationToken);
        }

        private IQueryable<TEntity> Include(Specification<TEntity> specification)
        {
            var query = entities.Where(x => true);

=======
            var query = entities.Where(x => true);
>>>>>>> eb8acc38da2f50c53d5b79eaa87bdd685850ed98
            if (specification.Include != null)
            {
                foreach (var include in specification.Include)
                {
                    query = query.Include(include);
                }
            }
<<<<<<< HEAD
            return query;
=======
            return query.Where(specification.Expression).ToPagedListAsync(pageNumber, pageSize, cancellationToken);
>>>>>>> eb8acc38da2f50c53d5b79eaa87bdd685850ed98
        }
    }
}

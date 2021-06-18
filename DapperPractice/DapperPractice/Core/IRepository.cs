using System;
using System.Collections.Generic;
using System.Text;

namespace DapperPractice.Core
{
    public interface IRepository<T> where T : class
    {
        void Create(T item);
        T FindById(int id);
        IEnumerable<T> Get(Func<T, bool> predicate);
        void Remove(T item);
        void Update(T item);
    }
}

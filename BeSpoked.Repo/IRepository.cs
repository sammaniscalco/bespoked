using BeSpoked.Repo.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BeSpoked.Repo
{
    public interface IRepository<T> where T : Entity
    {
        Task<List<T>> ToListAsync();
        Task<T> FindAsync(object id);
        IEnumerable<T> Filter(Func<T, bool> predicate);
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
        void Remove(object id);
        Task SaveChangesAsync();
        bool Exists(object id);

    }
}

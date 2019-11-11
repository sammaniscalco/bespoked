using BeSpoked.Repo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeSpoked.Repo
{
    public class BaseRepository<T> : IRepository<T> where T : Entity
    {
        private readonly BeSpokedContext _context;
        private readonly DbSet<T> _dbSet;

        public BaseRepository(BeSpokedContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public Task<List<T>> ToListAsync()
        {
            return _dbSet.ToListAsync();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }
        public void Remove(T entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }
            _dbSet.Remove(entity);
        }

        public void Remove(object id)
        {
            T entity = _dbSet.Find(id);
            Remove(entity);
        }

        public Task<T> FindAsync(object id)
        {
            return _dbSet.FindAsync(id);
        }
        public IEnumerable<T> Filter(Func<T, bool> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public Task SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        public bool Exists(object id)
        {
            return _dbSet.Any(e => e.Id == (long)id);
        }
    }
}

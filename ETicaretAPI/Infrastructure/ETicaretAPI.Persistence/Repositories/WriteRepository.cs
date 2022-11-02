using ETicaretAPI.Applicaton.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : class
    {
        private readonly Context _context;

        public WriteRepository(Context context)
        {
            _context = context;
        }
        public DbSet<T> Table => _context.Set<T>();

        public async Task<bool> AddAsync(T model)
        {
            EntityEntry<T> entityEntry = await Table.AddAsync(model);
            return entityEntry.State == EntityState.Added;
        }

        public async Task<bool> RemoveAsync(string id)
        {
            T model = await Table.FindAsync(Guid.Parse(id));
            return Remove(model);
        }

        public bool Remove(T model)
        {
            EntityEntry entityEntry = Table.Remove(model);
            return entityEntry?.State == EntityState.Deleted;
        }

        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }

        public Task<bool> UpdateAsync(T model)
        {
            throw new NotImplementedException();
        }
    }
}

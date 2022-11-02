using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Applicaton.Repositories
{
    public interface IWriteRepository<T> : IRepository<T> where T : class
    {
        public Task<bool> AddAsync(T model);

        Task<bool> RemoveAsync(string id);

        public bool Remove(T model);

        public Task<bool> UpdateAsync(T model);

        public Task<int> SaveChanges();
 
    }
}

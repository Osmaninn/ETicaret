using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaretAPI.Applicaton.Repositories.ProductRepository;
using ETicaretAPI.Domain.Entities;

namespace ETicaretAPI.Persistence.Repositories.ProductRepository
{
    internal class ProductReadRepository : ReadRepository<Product>, IProductReadRepository
    {
        public ProductReadRepository(Context context) : base(context)
        {
        }
    }
}

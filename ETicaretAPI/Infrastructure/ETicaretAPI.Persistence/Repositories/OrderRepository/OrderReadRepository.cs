using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaretAPI.Applicaton.Repositories.OrderRepository;
using ETicaretAPI.Domain.Entities;

namespace ETicaretAPI.Persistence.Repositories.OrderRepository
{
    public class OrderReadRepository : ReadRepository<Order>, IOrderReadRepository
    {
        public OrderReadRepository(Context context) : base(context)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaretAPI.Applicaton.Repositories.CustomerRepository;
using ETicaretAPI.Domain.Entities;

namespace ETicaretAPI.Persistence.Repositories.CustomerRepository
{
    public class CustomerReadRepository : ReadRepository<Customer>, ICustomerReadRepository
    {
        public CustomerReadRepository(Context context) : base(context)
        {
        }
    }
}

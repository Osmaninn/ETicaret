using ETicaretAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Applicaton.Features.Queries.Product.GetAllProducts
{
    public class GetAllProductsQueryResponse
    {
        public IQueryable<ETicaretAPI.Domain.Entities.Product> products { get; set; }

    }
}

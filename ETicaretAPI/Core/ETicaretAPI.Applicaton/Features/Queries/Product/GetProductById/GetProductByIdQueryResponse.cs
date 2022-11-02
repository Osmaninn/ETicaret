using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaretAPI.Domain.Entities;

namespace ETicaretAPI.Applicaton.Features.Queries.Product.GetProductById
{
    public class GetProductByIdQueryResponse
    {
        public ETicaretAPI.Domain.Entities.Product product { get; set; }
    }
}

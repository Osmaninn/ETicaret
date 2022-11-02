using ETicaretAPI.Applicaton.Features.Commands.Product.CreateProduct;
using ETicaretAPI.Applicaton.Features.Commands.Product.RemoveProduct;
using ETicaretAPI.Applicaton.Features.Queries.Product.GetProductById;
using ETicaretAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Applicaton.Abstractions.Services
{
    public interface IProductService
    {
        public IQueryable<Product> GetAll();

        public Task<bool> AddAsync(CreateProductCommandRequest model);

        public Task<Product> GetByIdAsync(GetProductByIdQueryRequest request);

        public Task<bool> RemoveAsync(RemoveProductCommandRequest request);
    }
}

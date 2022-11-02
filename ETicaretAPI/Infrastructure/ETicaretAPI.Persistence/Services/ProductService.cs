using ETicaretAPI.Applicaton.Abstractions.Services;
using ETicaretAPI.Applicaton.Features.Commands.Product.CreateProduct;
using ETicaretAPI.Applicaton.Features.Commands.Product.RemoveProduct;
using ETicaretAPI.Applicaton.Features.Queries.Product.GetProductById;
using ETicaretAPI.Applicaton.Repositories.ProductRepository;
using ETicaretAPI.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductReadRepository _productReadRepository;
        private readonly IProductWriteRepository _productWriteRepository;

        public ProductService(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
        }

        public IQueryable<Product> GetAll()
        {
            return _productReadRepository.GetAll();
        }

        public async Task<bool> AddAsync(CreateProductCommandRequest model)
        {
            await _productWriteRepository.AddAsync(new()
            {
                ProductName = model.ProductName,
                Price = model.Price,
                Stock = model.Stock
            });
            await _productWriteRepository.SaveChanges();
            
            return new();
        }

        public async Task<Product> GetByIdAsync(GetProductByIdQueryRequest request)
        {
            return (await _productReadRepository.GetByIdAsync(request.Id));
        }

        public async Task<bool> RemoveAsync(RemoveProductCommandRequest request)
        {
            await _productWriteRepository.RemoveAsync(request.productId);
            await _productWriteRepository.SaveChanges();
            return new();
        }
    }
}

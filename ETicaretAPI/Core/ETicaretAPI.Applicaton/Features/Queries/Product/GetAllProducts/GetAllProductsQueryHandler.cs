using ETicaretAPI.Applicaton.Abstractions.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Applicaton.Features.Queries.Product.GetAllProducts
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQueryRequest, GetAllProductsQueryResponse>
    {
        private IProductService _productService;

        public GetAllProductsQueryHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<GetAllProductsQueryResponse> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
        {
            var products = _productService.GetAll().Skip(request.Page * request.Size).Take(request.Size);
            return new()
            {
                products = products
            };
        }
    }
}

using ETicaretAPI.Applicaton.Abstractions.Services;
using MediatR;

namespace ETicaretAPI.Applicaton.Features.Commands.Product.RemoveProduct
{
    public class RemoveProductCommandHandler : IRequestHandler<RemoveProductCommandRequest, RemoveProductCommandResponse>
    {
        private IProductService _productService;

        public RemoveProductCommandHandler(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<RemoveProductCommandResponse> Handle(RemoveProductCommandRequest request, CancellationToken cancellationToken)
        {
            await _productService.RemoveAsync(request);

            return new();
        }
    }
}

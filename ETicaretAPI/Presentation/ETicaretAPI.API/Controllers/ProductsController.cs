using ETicaretAPI.Applicaton.Features.Commands.Product.CreateProduct;
using ETicaretAPI.Applicaton.Features.Commands.Product.RemoveProduct;
using ETicaretAPI.Applicaton.Features.Queries.Product.GetAllProducts;
using ETicaretAPI.Applicaton.Features.Queries.Product.GetProductById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody]CreateProductCommandRequest model)
        {
            CreateProductCommandResponse reponse= await _mediator.Send(model);
            return Ok();

        }

        [HttpGet]
        public async Task<ActionResult> GetAll([FromQuery]GetAllProductsQueryRequest getAllProductsQueryRequest)
        {
            GetAllProductsQueryResponse response = await _mediator.Send(getAllProductsQueryRequest);
            return Ok(response);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute]GetProductByIdQueryRequest request)
        {
            GetProductByIdQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("{productId}")]
        public async Task<IActionResult> Delete([FromRoute] RemoveProductCommandRequest request)
        {
            RemoveProductCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}

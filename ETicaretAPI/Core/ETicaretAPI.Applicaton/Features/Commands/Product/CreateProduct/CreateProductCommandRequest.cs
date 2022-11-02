using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Applicaton.Features.Commands.Product.CreateProduct
{
    public class CreateProductCommandRequest : IRequest<CreateProductCommandResponse>
    {
        public string ProductName{ get; set; }

        public  float Price{ get; set; }

        public int Stock { get; set; }
    }
}

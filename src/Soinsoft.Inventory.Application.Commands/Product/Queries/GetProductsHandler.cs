using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Soinsoft.Inventory.Application.Contracts.DTOs;

namespace Soinsoft.Inventory.Application.Commands.Product.Queries
{
    public class GetProductsHandler : IRequestHandler<GetProductsQry, IEnumerable<ProductDTO>>
    {
        public Task<IEnumerable<ProductDTO>> Handle(GetProductsQry request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
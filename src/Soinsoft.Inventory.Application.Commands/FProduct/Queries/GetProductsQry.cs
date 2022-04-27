using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Soinsoft.Inventory.Application.Contracts.DTOs;

namespace Soinsoft.Inventory.Application.Commands.FProduct.Queries
{
    public class GetProductsQry: IRequest<IEnumerable<ProductDTO>> 
    {
        
    }
}
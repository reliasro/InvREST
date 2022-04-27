using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Soinsoft.Inventory.Application.Commands.FProduct.Commands
{
    public class DeleteproductCmd: IRequest<int>
    {
        public int ProductId { get; set; }
    }
}
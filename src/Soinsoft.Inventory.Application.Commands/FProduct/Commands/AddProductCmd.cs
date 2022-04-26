using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Soinsoft.Inventory.Application.Commands.FProduct.Commands
{
    public class AddProductCmd: IRequest<int>
    {
        public string Description { get; set; }
        public Decimal Price { get; set; }
        public Decimal Cost { get; set; }
        public int Minimum { get; set; }
        public int Maximun { get; set; }
        public string Unit { get; set; }
    }
}
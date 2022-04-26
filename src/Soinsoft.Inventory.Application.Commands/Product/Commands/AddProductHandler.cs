using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Soinsoft.Inventory.Application.Commands.Product.Commands
{
    public class AddProductHandler : IRequestHandler<AddProductCmd, int>
    {
        public Task<int> Handle(AddProductCmd request, CancellationToken cancellationToken)
        {
            Console.WriteLine("Buenas tardes Elias");
            throw new NotImplementedException();
        }
    }
}
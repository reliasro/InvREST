using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Soinsoft.Inventory.Domain.Contracts;
using Soinsoft.Inventory.Domain.Model;

namespace Soinsoft.Inventory.Application.Commands.FProduct.Commands
{

    
    public class DeleteProductHandler: IRequestHandler<DeleteproductCmd,int>
    {
       private readonly IRepository<Product> _product;

        public DeleteProductHandler(IRepository<Product> product){
            _product = product;
        }

        public async Task<int> Handle(DeleteproductCmd request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
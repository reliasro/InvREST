using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Soinsoft.Inventory.Application.Commands.Events;
using Soinsoft.Inventory.Domain.Contracts;
using Soinsoft.Inventory.Domain.Model;

namespace Soinsoft.Inventory.Application.Commands.FProduct.Commands
{
    public class UpdateExistenceHandler : IRequestHandler<UpdateExistenceCmd, int>
    {
        private readonly IRepository<Product> _product;
        public UpdateExistenceHandler(IRepository<Product> product){
            _product = product;
        }

        public async Task<int> Handle(UpdateExistenceCmd request, CancellationToken cancellationToken)
        {
             var prd= await _product.Get(request.ProductId);
             prd.Existence+=request.ValueToAdjust;
             var res= await _product.SaveChanges();
             return res;
        }
    }
}
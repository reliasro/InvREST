using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Soinsoft.Inventory.Domain.Contracts;
using Soinsoft.Inventory.Domain.Model;

namespace Soinsoft.Inventory.Application.Commands.FProduct.Commands
{
    public class AddProductHandler : IRequestHandler<AddProductCmd, int>
    {
        private readonly IRepository<Product> _product;

        public AddProductHandler(IRepository<Product> product){
            _product = product;
        }

        public async Task<int> Handle(AddProductCmd request, CancellationToken cancellationToken)
        {
             Product p = new Product(){
                Description=request.Description,
                Maximun=request.Maximun,
                Minimum=request.Minimum,
                Price=request.Price,
                Cost=request.Cost,
                Unit=request.Unit
             };

            await _product.Create(p);
            return await _product.SaveChanges();
        }
    }
}
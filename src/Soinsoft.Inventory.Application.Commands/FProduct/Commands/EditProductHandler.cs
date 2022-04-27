using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Soinsoft.Inventory.Domain.Contracts;
using Soinsoft.Inventory.Domain.Model;

namespace Soinsoft.Inventory.Application.Commands.FProduct.Commands
{
    public class EditProductHandler : IRequestHandler<EditProductCmd, int>
    {
       private readonly IRepository<Product> _product;

        public EditProductHandler(IRepository<Product> product){
            _product = product;
        }
        
        public async  Task<int> Handle(EditProductCmd request, CancellationToken cancellationToken)
        {
             Product p = new Product(){
                Description=request.Description,
                Maximun=request.Maximun,
                Minimum=request.Minimum,
                Price=request.Price,
                Cost=request.Cost,
                Unit=request.Unit
             };

            await _product.Update(p);
            return await _product.SaveChanges();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Soinsoft.Inventory.Domain.Contracts;
using Soinsoft.Inventory.Domain.Model;
using AutoMapper;

namespace Soinsoft.Inventory.Application.Commands.FProduct.Commands
{
    public class AddProductHandler : IRequestHandler<AddProductCmd, int>
    {
        private readonly IRepository<Product> _product;
        private readonly IMapper _mapper;

        public AddProductHandler(IRepository<Product> product, IMapper mapper){
            _product = product;
            _mapper=mapper;
          }

        public async Task<int> Handle(AddProductCmd request, CancellationToken cancellationToken)
        {
            Product prod = _mapper.Map<Product>(request);

            await _product.Create(prod);
            return await _product.SaveChanges();
        }
    }
}
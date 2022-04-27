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
        private readonly MapperConfiguration _mapperconfig;

        public AddProductHandler(IRepository<Product> product){
            _product = product;
            _mapperconfig = new MapperConfiguration(opt=>opt.CreateMap<AddProductCmd, Product>());
        }

        public async Task<int> Handle(AddProductCmd request, CancellationToken cancellationToken)
        {
            var mapper = new Mapper(_mapperconfig);
            Product prod = mapper.Map<AddProductCmd, Product>(request);

          /*  Product p = new Product(){
                Description=request.Description,
                Maximun=request.Maximun,
                Minimum=request.Minimum,
                Price=request.Price,
                Cost=request.Cost,
                Unit=request.Unit
             }; */

            await _product.Create(prod);
            return await _product.SaveChanges();
        }
    }
}
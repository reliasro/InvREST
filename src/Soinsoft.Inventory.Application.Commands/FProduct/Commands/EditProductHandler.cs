using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Soinsoft.Inventory.Domain.Contracts;
using Soinsoft.Inventory.Domain.Model;

namespace Soinsoft.Inventory.Application.Commands.FProduct.Commands
{
    public class EditProductHandler : IRequestHandler<EditProductCmd, int>
    {
       private readonly IRepository<Product> _product;
        private readonly IMapper _mapper;

        public EditProductHandler(IRepository<Product> product, IMapper mapper){
            _product = product;
            _mapper = mapper;
        }
        
        public async  Task<int> Handle(EditProductCmd request, CancellationToken cancellationToken)
        {
            Product t =await _product.Get(request.Id); //Read product from repo
            
            //Update product
            /*
            t.Description=request.Description;
            t.Maximun=request.Maximun;
            t.Minimum=request.Minimum;
            t.Price=request.Price;
            t.Cost=request.Cost;
            t.Unit=request.Unit;
            */
            _mapper.Map<EditProductCmd,Product>(request,t);
            await _product.Update(t);
            return await _product.SaveChanges();
        }
    }
}
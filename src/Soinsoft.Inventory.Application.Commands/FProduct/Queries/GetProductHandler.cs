using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Soinsoft.Inventory.Application.Contracts.DTOs;
using Soinsoft.Inventory.Domain.Contracts;
using Soinsoft.Inventory.Domain.Model;

namespace Soinsoft.Inventory.Application.Commands.FProduct.Queries
{
    public class GetProductHandler : IRequestHandler<GetProductQry, ProductDTO>
    {
        private readonly IRepository<Product> _repository;
        private readonly IMapper _mapper;
        public GetProductHandler(IRepository<Product> repository, IMapper mapper ){
            _mapper = mapper;
            _repository = repository;

        }
        public async Task<ProductDTO> Handle(GetProductQry request, CancellationToken cancellationToken)
        {
           var result= _repository.Get(request.Id);
           var p= _mapper.Map<ProductDTO>(result.Result);
           await Task.FromResult(p);
           return p;
        }
    }
}
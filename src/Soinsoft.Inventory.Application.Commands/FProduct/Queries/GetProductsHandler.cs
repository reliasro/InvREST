using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Soinsoft.Inventory.Application.Contracts.DTOs;
using Soinsoft.Inventory.Domain.Contracts;
using Soinsoft.Inventory.Domain.Model;
using AutoMapper;

namespace Soinsoft.Inventory.Application.Commands.FProduct.Queries
{
    public class GetProductsHandler : IRequestHandler<GetProductsQry, IEnumerable<ProductDTO>>
    {
        private readonly IRepository<Product> _repository;
        private readonly IMapper _mapper;
        public GetProductsHandler(IRepository<Product> repository, IMapper mapper ){
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<IEnumerable<ProductDTO>> Handle(GetProductsQry request, CancellationToken cancellationToken)
        {
           var result= await _repository.GetAll();
           return _mapper.Map<List<ProductDTO>>(result);
        }
    }
}
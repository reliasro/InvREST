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
    public class GetCurrentStockHandler : IRequestHandler<GetCurrentStockQry, IEnumerable<StockDTO>>
    {
        private readonly IRepository<Product> _repository;
        private readonly IMapper _mapper;
        public GetCurrentStockHandler(IRepository<Product> repository, IMapper mapper ){
            _mapper = mapper;
            _repository = repository;
        }        
        public async Task<IEnumerable<StockDTO>> Handle(GetCurrentStockQry request, CancellationToken cancellationToken)
        {
           var result= await _repository.GetAll();
           return _mapper.Map<List<StockDTO>>(result);
        }
    }
}
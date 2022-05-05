using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Soinsoft.Inventory.Application.Commands.FProduct.Commands
{
    public class UpdateExistenceCmd:IRequest<int>
    {
        public int ProductId { get; set; } 
        public int ValueToAdjust { get; set; }
        
    }
}
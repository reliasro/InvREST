using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Soinsoft.Inventory.Application.Commands.Events
{
    public class TransacctionSaved:INotification
    {
        public int ProductId { get; set; }
        public int ValueToAdjust { get; set; }
        
    }
}
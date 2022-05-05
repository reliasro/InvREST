using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Soinsoft.Inventory.Domain.Model;

namespace Soinsoft.Inventory.Application.Commands.Events
{
    public class TransactionSaved:INotification
    {
        public int ProductId { get; set; }
        public int ValueToAdjust { get; set; }
        public TransactionType TransactionType { get; set; }
        
    }
}
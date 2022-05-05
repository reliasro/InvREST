using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Soinsoft.Inventory.Domain.Model;

namespace Soinsoft.Inventory.Application.Commands.FTransacctions.Commands
{

    public class SaleCmd: IRequest<int>
    {

       public int ProductID { get; set; }
        public string ProductDescription { get; set; }
        public Decimal Price { get; set; }
        public int InitialExistence { get; set; }
        public TransactionType TransacctionType { get; set; }
        public int Value { get; set; }
        public string Comments { get; set; }
        public DateTime Date { get; set; }          
    }
}
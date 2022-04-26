using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soinsoft.Inventory.Domain.Model
{
    public class Transaction
    {
        public int ProductID { get; set; }
        public int Id { get; set; }
        public int InitialExistence { get; set; }
        public int FinalExistence { get; set; }
        public TransactionType TransacctionType { get; set; }
        public int Value { get; set; }
        public string Comments { get; set; }
        public DateTime Date { get; set; }

    }
}
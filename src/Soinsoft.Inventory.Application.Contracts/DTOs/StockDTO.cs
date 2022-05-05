using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soinsoft.Inventory.Application.Contracts.DTOs
{
    public class StockDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public Decimal Price { get; set; }        
        public int Existence { get; set; }
        public int Minimum { get; set; }
    }
}
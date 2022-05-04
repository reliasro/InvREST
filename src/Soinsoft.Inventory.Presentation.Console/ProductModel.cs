using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soinsoft.Inventory.Presentation.Console
{
    public class ProductModel
    {
        public string Description { get; set; }
        public Decimal Price { get; set; }
        public Decimal Cost { get; set; }
        public int Minimum { get; set; }
        public int Maximun { get; set; }
        public string Unit { get; set; }        
    }
}
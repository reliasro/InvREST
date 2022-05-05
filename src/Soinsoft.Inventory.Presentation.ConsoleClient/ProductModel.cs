using System;

namespace Soinsoft.Inventory.Presentation.ConsoleClient
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
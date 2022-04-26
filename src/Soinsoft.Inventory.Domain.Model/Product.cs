namespace Soinsoft.Inventory.Domain.Model;
public class Product
{
   public int Id { get; set; }
   public string Description { get; set; }
   public Decimal Price { get; set; }
   public Decimal Cost { get; set; }
   public int Minimum { get; set; }
   public int Maximun { get; set; }

   public string Unit { get; set; }

   public int Existence { get; set; }
}

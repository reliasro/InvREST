using System;
using System.Net.Http;
using System.Threading.Tasks;


namespace Soinsoft.Inventory.Presentation.ConsoleClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await ConsumirAPI();        
        }

        static async Task ConsumirAPI(){

            ProductModel prd1 = new ProductModel{
                Description="Product 203 created from Client",
                Maximun=25,
                Minimum=15,
                Cost=3500,
                Price=5500,
                Unit="Unit"    
            };
            ProductModel prd2 = new ProductModel{
                Description="Product 204 created from Client",
                Maximun=73,
                Minimum=36,
                Cost=6000,
                Price=8600,
                Unit="Unit"    
            };

            APIClient client= new APIClient();

            //Adding products
            await client.AddProduct(prd1);
            await client.AddProduct(prd2);
            
            //Editing
            prd1.Description="Product #16 edited 3 times";
            await client.EditProduct(16, prd1);
             
            //Reading 
            ProductModel resp= await client.Getproduct(16);
            Console.WriteLine($"Requested Product 16: {resp.Description}");
            
            //Deleting #15
            await client.DeleteProduct(14);
            Console.WriteLine($"Product #14 removed");            
            Console.WriteLine($"Inventory Web API Client");            
        }
    }
}

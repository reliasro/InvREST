// See https://aka.ms/new-console-template for more information
using Soinsoft.Inventory.Presentation.Console;

Product prd1 = new Product{
    Description="Product1 created from Client",
    Maximun=85,
    Minimum=36,
    Cost=1500,
    Price=2500,
    Unit="Unit"    
};
Product prd2 = new Product{
    Description="Product2 created from Client",
    Maximun=75,
    Minimum=50,
    Cost=6000,
    Price=13600,
    Unit="Unit"    
};

int[] ids= new int[3];

APIClient client= new APIClient();
ids[0]= await client.AddProduct(prd1);
ids[1]= await client.AddProduct(prd2);
await client.Getproduct(ids[0]);
prd1.Description="Product edited from client";
await client.EditProduct(ids[0], prd1);
await client.Getproduct(ids[1]);
await client.DeleteProduct(ids[0]);
Console.WriteLine($"Inventory Web API Client");


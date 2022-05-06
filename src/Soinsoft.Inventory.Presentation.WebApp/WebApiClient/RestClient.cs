using System.Net.Http.Headers;

namespace Soinsoft.Inventory.Presentation.WebApp.WebApiClient
{
    public class RestClient
    {
        private HttpClient _Client { get; set; }
        
        public RestClient(){
               _Client= new HttpClient();
              // _httpClient.BaseAddress=new Uri("https://localhost:5000/v1/api/Inventory/");
               _Client.BaseAddress=new Uri("https://localhost:7777/");
               _Client.DefaultRequestHeaders.Accept.Clear();
               _Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<ProductModel> GetProduct(int id){

            HttpResponseMessage resp =await  _Client.GetAsync($"Product/{id}");
            Console.WriteLine($"Hola base:  {_Client.BaseAddress}");
            resp.EnsureSuccessStatusCode();
            try
            {
               ProductModel prd= null;
               prd= await resp.Content.ReadAsAsync<ProductModel>();                   
               return prd;
            }
            catch (System.Exception err)
            {
                throw new Exception(err.Message,err);
            }
        }
        
    }
}
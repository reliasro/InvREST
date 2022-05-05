using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Soinsoft.Inventory.Presentation.ConsoleClient
{
    public class APIClient
    {
        HttpClient _client;
        public APIClient(){
            
            _client= new HttpClient();
            _client.BaseAddress= new Uri( "https://localhost:5000/api/v1/Inventory/");
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
              new MediaTypeWithQualityHeaderValue("application/json"));            
        }

        public async Task<Uri> AddProduct(ProductModel prd){
            
            HttpResponseMessage resp = await _client.PostAsJsonAsync("AddProduct",prd);
            resp.EnsureSuccessStatusCode();
            return resp.Headers.Location;

        }

        public async Task<int> EditProduct(int id, ProductModel prd){

            HttpResponseMessage resp = await _client.PutAsJsonAsync($"EditProduct/{id}",prd);
            resp.EnsureSuccessStatusCode();
            return 1;

        }

        public async Task<int> DeleteProduct(int id){
            HttpResponseMessage resp = await _client.DeleteAsync($"DeleteProduct/{id}");
            resp.EnsureSuccessStatusCode();
            return 1;
        }

        public async Task<ProductModel> Getproduct(int id){
            
            ProductModel prd=null;
            HttpResponseMessage resp = await _client.GetAsync($"Product/{id}");
            
            if (resp.IsSuccessStatusCode)
            {
              prd =await  resp.Content.ReadAsAsync<ProductModel>();
            }
            return prd;
        }

    }
}
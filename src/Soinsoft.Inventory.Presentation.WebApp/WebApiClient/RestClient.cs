using System.Net.Http.Headers;

namespace Soinsoft.Inventory.Presentation.WebApp.WebApiClient
{

    public interface IRestClient
    {
        Task<int> DeleteProduct(int id);
        Task<ProductModel> GetProduct(int id);
        Task<IEnumerable<ProductModel>> GetProductList();
        Task<int> UpdateProduct(ProductModel prd);
    }

    public class RestClient : IRestClient
    {
        private HttpClient _Client { get; set; }

        public RestClient()
        {
            _Client = new HttpClient();
            _Client.BaseAddress = new Uri("https://localhost:5000/api/v1/Inventory/");
            _Client.DefaultRequestHeaders.Accept.Clear();
            _Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<ProductModel> GetProduct(int id)
        {
            HttpResponseMessage resp = await _Client.GetAsync($"Product/{id}");
            resp.EnsureSuccessStatusCode(); //Return 200-299 code
            try
            {
                ProductModel prd = null;
                prd = await resp.Content.ReadAsAsync<ProductModel>();
                return prd;
            }
            catch (System.Exception err)
            {
                throw new Exception(err.Message, err);
            }
        }

        public async Task<int> UpdateProduct(ProductModel prd)
        {
            HttpResponseMessage resp = await _Client.PutAsJsonAsync<ProductModel>($"EditProduct/{prd.Id}", prd);
            resp.EnsureSuccessStatusCode(); //Return 200-299 code
            try
            {
                return 1;
            }
            catch (System.Exception err)
            {
                throw new Exception(err.Message, err);
            }
        }

        public async Task<int> DeleteProduct(int id)
        {
            HttpResponseMessage resp = await _Client.DeleteAsync($"DeleteProduct/{id}");
            resp.EnsureSuccessStatusCode(); //Return 200-299 code
            try
            {
                return 1;
            }
            catch (System.Exception err)
            {
                throw new Exception(err.Message, err);
            }
        }


        public async Task<IEnumerable<ProductModel>> GetProductList()
        {
            HttpResponseMessage resp = await _Client.GetAsync("Products");
            resp.EnsureSuccessStatusCode(); //Return 200-299 code
            try
            {
                IEnumerable<ProductModel> list = null;
                list = await resp.Content.ReadAsAsync<IEnumerable<ProductModel>>();
                return list;
            }
            catch (System.Exception err)
            {
                throw new Exception(err.Message, err);
            }
        }

    }
}
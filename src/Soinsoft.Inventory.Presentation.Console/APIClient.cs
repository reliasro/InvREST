using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;

namespace Soinsoft.Inventory.Presentation.Console
{
    public class APIClient
    {
        private HttpClient client = new HttpClient();
        public APIClient(){

        }

        public async Task<int> AddProduct(Product prd){
            return 1;
        }
        public async Task<int> EditProduct(int id, Product prd){
            return 1;
        }
        public async Task<int> DeleteProduct(int id){
            return 1;
        }

        public async Task<Product> Getproduct(int id){
            return new Product();
        }

    }
}
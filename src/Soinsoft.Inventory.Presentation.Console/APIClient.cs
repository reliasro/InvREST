using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Soinsoft.Inventory.Presentation.Console
{
    public class APIClient
    {
        public APIClient(){

        }

        public async Task<int> AddProduct(ProductModel prd){
            return 1;
        }
        public async Task<int> EditProduct(int id, ProductModel prd){
            return 1;
        }
        public async Task<int> DeleteProduct(int id){
            return 1;
        }

        public async Task<ProductModel> Getproduct(int id){
            return new ProductModel();
        }

    }
}
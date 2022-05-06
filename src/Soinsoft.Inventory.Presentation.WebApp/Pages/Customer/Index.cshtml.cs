using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Soinsoft.Inventory.Presentation.WebApp.WebApiClient;

namespace Soinsoft.Inventory.Presentation.WebApp.Pages.Customer
{
    public class Index : PageModel
    {
        private readonly ILogger<Index> _logger;
        private readonly IRestClient _restClient;

        public Index(ILogger<Index> logger, IRestClient restClient)
        {
            _restClient = restClient;
            _logger = logger;
        }

        public ProductModel Product { get; set; }
        public IEnumerable<ProductModel> ProductList { get; set; }

        public async Task OnGet()
        {
            try
            {

                var prd= await _restClient.GetProduct(1);
                prd.Description="I Have Edited From Razor Page 4";
                await _restClient.UpdateProduct(prd);

                //Read product list 
                var res= await _restClient.GetProductList();
                this.ProductList= res;
            }
            catch (System.Exception err)
            {
                
               throw new Exception(err.Message,err);
            }
        }
    }
}
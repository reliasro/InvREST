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

        public Index(ILogger<Index> logger)
        {
            _logger = logger;
        }

        public ProductModel Product { get; set; }
        public void OnGet()
        {
            try
            {
                RestClient client= new RestClient();
                var res= client.GetProduct(1);
                this.Product= res.Result;
            }
            catch (System.Exception err)
            {
                
               throw new Exception(err.Message,err);
            }
        }
    }
}
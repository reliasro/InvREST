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
    public class Detail : PageModel
    {
        private readonly ILogger<Detail> _logger;
        private readonly IRestClient _restClient;

        [BindProperty(SupportsGet =true)] 
        public int id { get; set; }
        [BindProperty]
        public string Description { get; set; }
        [BindProperty]
        public Decimal Price { get; set; }
        public Detail(ILogger<Detail> logger, IRestClient restClient)
        {
            _restClient = restClient;
            _logger = logger;
        }

        public async Task OnGet()
        {
           var prd= await _restClient.GetProduct(id);
           Description=prd.Description;
           Price=prd.Price;
        }

        public async Task<IActionResult> OnPost(){
           
           //Editing description
           var prd= await _restClient.GetProduct(id);
           prd.Description=Description;
           prd.Price=Price;
           await _restClient.UpdateProduct(prd);
           return RedirectToPage("/Customer/Index");   
                       
        }
    }
}
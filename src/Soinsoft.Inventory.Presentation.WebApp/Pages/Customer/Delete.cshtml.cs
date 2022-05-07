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
    public class Delete : PageModel
    {
        private readonly ILogger<Delete> _logger;
        private readonly IRestClient _restClient;

        public Delete(ILogger<Delete> logger, IRestClient restClient)
        {
            _restClient = restClient;
            _logger = logger;
        }

        [BindProperty(SupportsGet =true)] 
        public int Id { get; set; }
        
        public void OnGet()
        {
        }
        
    
        public async Task<IActionResult> OnPost(){

          var i= await _restClient.DeleteProduct(Id);
          return RedirectToPage("/Customer/Index");   

        }
    }
}
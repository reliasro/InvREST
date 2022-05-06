using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Soinsoft.Inventory.Presentation.WebApp.Pages.Customer
{
    public class Detail : PageModel
    {
        private readonly ILogger<Detail> _logger;

        public Detail(ILogger<Detail> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}
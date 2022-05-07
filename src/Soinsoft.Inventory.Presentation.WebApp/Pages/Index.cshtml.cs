using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Soinsoft.Inventory.Presentation.WebApp.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    public string Greetings { get; set; }

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
        Greetings="Hey Welcome to this World of Razor Pages";
    }

    public IActionResult OnGet()
    {
       return RedirectToPage("/Customer/Index");
    }
}

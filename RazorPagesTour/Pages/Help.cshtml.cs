using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesTour.Pages
{
    public class HelpModel : PageModel
    {
        public async Task<IActionResult> OnGet()
        {
            await Task.CompletedTask;
            return Page();
        }
    }
}

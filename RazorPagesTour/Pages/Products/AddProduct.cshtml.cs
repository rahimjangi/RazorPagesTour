using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesTour.Data;

namespace RazorPagesTour.Pages.Products;

public class AddProductModel : PageModel
{
    [BindProperty]
    public Product Product { get; set; } = default!;
    public void OnGet()
    {
    }

    public ActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        return RedirectToPage("ViewAllProducts");

    }
}

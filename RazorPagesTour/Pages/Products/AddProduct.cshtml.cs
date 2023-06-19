using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesTour.Data;

namespace RazorPagesTour.Pages.Products;

public class AddProductModel : PageModel
{
    private readonly ApplicationDataContext _context;
    private readonly IWebHostEnvironment _environment;
    public AddProductModel(ApplicationDataContext context, IWebHostEnvironment environment)
    {
        _context = context;
        _environment = environment;
    }
    [BindProperty]
    public Product Product { get; set; } = default!;
    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
        if (Product.Upload != null)
        {
            Product.ImageFileName = Product.Upload.FileName;
            var file = Path.Combine(_environment.ContentRootPath, "wwwroot/images/menu", Product.Upload.FileName);
            using (var stream = new FileStream(file, FileMode.Create))
            {
                await Product.Upload.CopyToAsync(stream);
            }
        }
        Product.Created = DateTime.Now;
        _context.Products.Add(Product);
        var numberOfRecords = _context.SaveChanges();
        return RedirectToPage("ViewAllProducts");

    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesTour.Data;

namespace RazorPagesTour.Pages.Products;

public class AddProductModel : PageModel
{
    private readonly IProductRepository<Product> _productRepository;
    private readonly IWebHostEnvironment _environment;
    public AddProductModel(IWebHostEnvironment environment, IProductRepository<Product> productRepository)
    {
        _environment = environment;
        _productRepository = productRepository;
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
        await _productRepository.Add(Product);
        return RedirectToPage("ViewAllProducts");

    }
}

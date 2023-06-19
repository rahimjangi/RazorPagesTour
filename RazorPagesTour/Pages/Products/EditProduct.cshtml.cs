using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesTour.Data;

namespace RazorPagesTour.Pages.Products;

public class EditProductModel : PageModel
{
    private readonly IHostEnvironment _environment;
    private readonly IProductRepository<Product> _productRepository;
    [BindProperty]
    public Product? Product { get; set; } = new Product();
    [FromRoute]
    public int Id { get; set; }

    public EditProductModel(IProductRepository<Product> productRepository, IHostEnvironment environment)
    {
        _productRepository = productRepository;
        _environment = environment;
    }
    public async Task OnGet()
    {
        Product = await _productRepository.GetById(Id);
    }

    public async Task<IActionResult> OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
        var currentObj = await _productRepository.GetById(Id);
        var currentImageFileName = currentObj.ImageFileName;
        var currentFile = Path.Combine(_environment.ContentRootPath, "wwwroot/images/menu", currentImageFileName);

        var fileinfo = new FileInfo(currentFile);
        if (fileinfo.Exists)
        {
            fileinfo.Delete();
        }
        if (Product.Upload != null)
        {
            Product.ImageFileName = Product.Upload.FileName;
            var file = Path.Combine(_environment.ContentRootPath, "wwwroot/images/menu", Product.Upload.FileName);
            using (var fileStreem = new FileStream(file, FileMode.Create))
            {
                await Product.Upload.CopyToAsync(fileStreem);
            }
        }
        Product.Id = Id;
        _productRepository.Update(Product);
        return RedirectToPage("ViewAllProducts");
    }
}

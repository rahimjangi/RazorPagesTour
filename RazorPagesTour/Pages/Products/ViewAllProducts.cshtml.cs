using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesTour.Data;

namespace RazorPagesTour.Pages.Products;

public class ViewAllProductsModel : PageModel
{
    private readonly IProductRepository<Product> _repository;

    [BindProperty]
    public List<Product> Products { get; set; } = new List<Product>();

    public ViewAllProductsModel(IProductRepository<Product> repository)
    {
        _repository = repository;
        _repository = repository;
    }
    public async Task OnGet()
    {
        Products.AddRange(await _repository.GetAll());
    }
}

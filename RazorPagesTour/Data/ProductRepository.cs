using Microsoft.EntityFrameworkCore;

namespace RazorPagesTour.Data;

public class ProductRepository : IProductRepository<Product>
{
    private readonly ApplicationDataContext _context;

    public ProductRepository(ApplicationDataContext context)
    {
        _context = context;
    }

    public async Task Add(Product obj)
    {
        await _context.Products.AddAsync(obj);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(Product obj)
    {
        _context.Products.Remove(obj);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Product>> GetAll()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task<Product> GetById(int id)
    {
        return await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
    }

    public void Update(Product obj)
    {
        var local = _context.Set<Product>()
    .Local
    .FirstOrDefault(entry => entry.Id.Equals(obj.Id));

        // check if local is not null 
        if (local != null)
        {
            // detach
            _context.Entry(local).State = EntityState.Detached;
        }
        // set Modified flag in your entry
        _context.Entry(obj).State = EntityState.Modified;

        // save 
        _context.SaveChanges();
    }
}

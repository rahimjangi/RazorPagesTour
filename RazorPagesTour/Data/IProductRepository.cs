namespace RazorPagesTour.Data;

public interface IProductRepository<T>
{
    Task Add(T obj);
    void Update(T obj);
    Task Delete(T obj);
    Task<T> GetById(int id);
    Task<List<T>> GetAll();
}

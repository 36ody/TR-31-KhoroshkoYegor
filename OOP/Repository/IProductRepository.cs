public interface IProductRepository
{
    void Create(Product product);
    Product Read(int id);
    void Update(Product product);
    void Delete(int id);
    List<Product> GetAll();
}
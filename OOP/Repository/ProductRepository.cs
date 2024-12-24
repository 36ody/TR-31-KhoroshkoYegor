public class ProductRepository : IProductRepository
{
    private readonly DbContext _context;

    public ProductRepository(DbContext context)
    {
        _context = context;
    }

    public void Create(Product product)
    {
        _context.Products.Add(product);
    }

    public Product Read(int id)
    {
        return _context.Products.FirstOrDefault(p => p.Id == id);
    }

    public void Update(Product product)
    {
        var existingProduct = Read(product.Id);
        if (existingProduct != null)
        {
            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;
        }
    }

    public void Delete(int id)
    {
        var product = Read(id);
        if (product != null)
        {
            _context.Products.Remove(product);
        }
    }

    public List<Product> GetAll()
    {
        return _context.Products;
    }
}
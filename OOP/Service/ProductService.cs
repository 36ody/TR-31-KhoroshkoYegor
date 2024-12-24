using OOP.Repository;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IUserRepository _userRepository;

    public ProductService(IProductRepository productRepository, IUserRepository userRepository)
    {
        _productRepository = productRepository;
        _userRepository = userRepository;
    }

    public List<Product> ViewProducts()
    {
        return _productRepository.GetAll();
    }

    public void AddProduct(Product product)
    {
        _productRepository.Create(product);
    }

    public bool PurchaseProduct(string username, int productId)
    {
        var user = _userRepository.Read(username);
        var product = _productRepository.Read(productId);
        if (user != null && product != null && user.Balance >= product.Price)
        {
            user.Balance -= product.Price;
            user.PurchaseHistory.Add(product);
            _userRepository.Update(user);
            return true;
        }
        return false;
    }
}
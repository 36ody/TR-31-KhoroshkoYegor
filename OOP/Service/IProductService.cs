public interface IProductService
{
    List<Product> ViewProducts();
    void AddProduct(Product product);
    bool PurchaseProduct(string username, int productId);
}
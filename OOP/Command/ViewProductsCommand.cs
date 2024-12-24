public class ViewProductsCommand : ICommand
{
    private readonly IProductService _productService;

    public ViewProductsCommand(IProductService productService)
    {
        _productService = productService;
    }

    public void Execute()
    {
        var products = _productService.ViewProducts();
        Console.WriteLine("Available Products:");
        foreach (var product in products)
        {
            Console.WriteLine($"{product.Id}. {product.Name} - {product.Price}");
        }
    }

    public void DisplayOptions()
    {
        Console.WriteLine("1. View available products.");
    }
}
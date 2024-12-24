public class AddProductCommand : ICommand
{
    private readonly IProductService _productService;

    public AddProductCommand(IProductService productService)
    {
        _productService = productService;
    }

    public void Execute()
    {
        Console.Write("Enter product name: ");
        string productName = Console.ReadLine();
        Console.Write("Enter product price: ");
        decimal productPrice = decimal.Parse(Console.ReadLine());

        if (productPrice < 0)
        {
            Console.WriteLine("Product price cannot be negative.");
            return;
        }

        var product = new Product(productName, productPrice);
        _productService.AddProduct(product);
        Console.WriteLine("Product added successfully.");
    }

    public void DisplayOptions()
    {
        Console.WriteLine("5. Add a new product.");
    }
}
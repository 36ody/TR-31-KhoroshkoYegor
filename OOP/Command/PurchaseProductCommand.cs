public class PurchaseProductCommand : ICommand
{
    private readonly IProductService _productService;
    private readonly string _username;

    public PurchaseProductCommand(IProductService productService, string username)
    {
        _productService = productService;
        _username = username;
    }

    public void Execute()
    {
        Console.Write("Enter product ID to purchase: ");
        int productId = int.Parse(Console.ReadLine());
        if (_productService.PurchaseProduct(_username, productId))
        {
            Console.WriteLine("Product purchased successfully.");
        }
        else
        {
            Console.WriteLine("Purchase failed. Check your balance or product ID.");
        }
    }

    public void DisplayOptions()
    {
        Console.WriteLine("3. Purchase a product.");
    }
}
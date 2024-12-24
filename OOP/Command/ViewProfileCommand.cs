using OOP.Repository;

public class ViewProfileCommand : ICommand
{
    private readonly IUserService _userService;
    private readonly string _username;

    public ViewProfileCommand(IUserService userService, string username)
    {
        _userService = userService;
        _username = username;
    }

    public void Execute()
    {
        var user = _userService.ViewProfile(_username);
        if (user != null)
        {
            Console.WriteLine($"Username: {user.Username}");
            Console.WriteLine($"Balance: {user.Balance}");
            Console.WriteLine("Purchase History:");
            foreach (var product in user.PurchaseHistory)
            {
                Console.WriteLine($"- {product.Name}: {product.Price}");
            }
        }
        else
        {
            Console.WriteLine("User not found.");
        }
    }

    public void DisplayOptions()
    {
        Console.WriteLine("4. View profile.");
    }
}
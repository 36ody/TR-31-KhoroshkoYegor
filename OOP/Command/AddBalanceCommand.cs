public class AddBalanceCommand : ICommand
{
    private readonly IUserService _userService;
    private readonly string _username;

    public AddBalanceCommand(IUserService userService, string username)
    {
        _userService = userService;
        _username = username;
    }
    
    public void Execute()
    {
        Console.Write("Enter amount to add: ");
        decimal amount = decimal.Parse(Console.ReadLine());

        if (amount < 0)
        {
            Console.WriteLine("Balance amount cannot be negative.");
            return;
        }

        _userService.AddBalance(_username, amount);
        Console.WriteLine("Balance updated successfully.");
    }

    public void DisplayOptions()
    {
        Console.WriteLine("2. Add balance to the user account.");
    }
}